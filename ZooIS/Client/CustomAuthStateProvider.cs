using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace ZooIS.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            RemoveExpiredTokens();
            string token = await _localStorage.GetItemAsStringAsync("idToken");

            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    identity = new ClaimsIdentity(SaitynoLab.Client.JwtParser.ParseClaimsFromJwt(token), "jwt");

                    _http.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                }
            }
            catch (Exception ex)
            {
                identity = new ClaimsIdentity();
                await _localStorage.RemoveItemAsync("idToken");
                Console.WriteLine("No fiddle with tokens !!!");
            }


            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return (state);
        }

        async void RemoveExpiredTokens()
        {
            if (DateTime.Now > await _localStorage.GetItemAsync<DateTime>("idTokenExpirationDate"))
            {
                await _localStorage.RemoveItemAsync("idToken");
                await _localStorage.RemoveItemAsync("userId");
                await _localStorage.RemoveItemAsync("idTokenExpirationDate");
                await _localStorage.RemoveItemAsync("stayLoggedIn");
            }
        }
    }
}
