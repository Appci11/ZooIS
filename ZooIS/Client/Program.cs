global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ZooIS.Client;
using ZooIS.Client.Services.AreasService;
using ZooIS.Client.Services.AuthService;
using ZooIS.Client.Services.TagsService;
using ZooIS.Client.Services.UserSettingsService;
using ZooIS.Client.Services.UsersService;
using ZooIS.Client.Services.ZooMapService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserSettingsService, UserSettingsService>();
builder.Services.AddScoped<IZooMapService, ZooMapService>();
builder.Services.AddScoped<IAreasService, AreasService>();
builder.Services.AddScoped<ITagsService, TagsService>();

await builder.Build().RunAsync();
