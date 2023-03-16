using Blazored.LocalStorage;
using System.Net.Http.Json;
using ZooIS.Shared.Dto;

namespace ZooIS.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        // Jei nepavyks kartu client ir server laikyt, nepamirst api rakto
        //const string apiKey = "Labai_slaptas_raktas";

        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authProvider;

        public AuthService(HttpClient http, ILocalStorageService localStorage, AuthenticationStateProvider authProvider)
        {
            _http = http;
            _localStorage = localStorage;
            _authProvider = authProvider;
        }
        public async Task<bool> Register(RegisterUserDto registerUserDto)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync("/api/register", registerUserDto);
            if (response.IsSuccessStatusCode)
            {
                AuthResponseDto responseDto = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
                if (responseDto != null)
                {
                    await _localStorage.SetItemAsync<string>("idToken", responseDto.IdToken);
                    await _localStorage.SetItemAsync<DateTime>("idTokenExpirationDate", responseDto.ExpiresIn);
                    await _localStorage.SetItemAsync<string>("username", responseDto.Username);
                    await _localStorage.SetItemAsync<int>("userId", responseDto.UserId);
                    await _localStorage.SetItemAsync<string>("refreshToken", responseDto.RefreshToken);
                    await _authProvider.GetAuthenticationStateAsync();
                    return true;
                }
            }
            return false;
        }
        public async Task<int> Login(AuthUserDto authUserDto, bool stayLoggedIn)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync("/api/login", authUserDto);
            if (response.IsSuccessStatusCode)
            {
                AuthResponseDto responseDto = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
                if (responseDto != null)
                {
                    if(responseDto.PassResetRequest)
                    {
                        return 2;
                    }
                    await _localStorage.SetItemAsync<string>("idToken", responseDto.IdToken);
                    await _localStorage.SetItemAsync<DateTime>("idTokenExpirationDate", responseDto.ExpiresIn);
                    await _localStorage.SetItemAsync<string>("username", responseDto.Username);
                    await _localStorage.SetItemAsync<int>("userId", responseDto.UserId);
                    await _localStorage.SetItemAsync<string>("refreshToken", responseDto.RefreshToken);
                    if (stayLoggedIn) await _localStorage.SetItemAsync<bool>("stayLoggedIn", true);
                    await _authProvider.GetAuthenticationStateAsync();
                    return 1;
                }
            }
            return 0;
        }

        public async Task<bool> Logout()
        {
            try {
                await _localStorage.RemoveItemAsync("idToken");
                await _localStorage.RemoveItemAsync("idTokenExpirationDate");
                await _localStorage.RemoveItemAsync("username");
                await _localStorage.RemoveItemAsync("userId");
                await _localStorage.RemoveItemAsync("refreshToken");
                await _localStorage.RemoveItemAsync("stayLoggedIn");
                await _authProvider.GetAuthenticationStateAsync();
                return true;
            }
            catch (Exception ex) { Console.Error.WriteLine(ex); }
            return false;
            
        }

        public Task<bool> RefreshTokens()
        {
            throw new NotImplementedException();
        }


    }
}
