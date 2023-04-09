global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ZooIS.Client;
using ZooIS.Client.Services.AnimalsService;
using ZooIS.Client.Services.AreasService;
using ZooIS.Client.Services.AuthService;
using ZooIS.Client.Services.BundlesService;
using ZooIS.Client.Services.EmployeesService;
using ZooIS.Client.Services.HabitatsService;
using ZooIS.Client.Services.PicturesService;
using ZooIS.Client.Services.SpeciesService;
using ZooIS.Client.Services.TagsService;
using ZooIS.Client.Services.TicketsService;
using ZooIS.Client.Services.UsersService;
using ZooIS.Client.Services.WorkTasksService;
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
builder.Services.AddScoped<IZooMapService, ZooMapService>();
builder.Services.AddScoped<IAreasService, AreasService>();
builder.Services.AddScoped<ITagsService, TagsService>();
builder.Services.AddScoped<IHabitatsService, HabitatsService>();
builder.Services.AddScoped<IAnimalsService, AnimalsService>();
builder.Services.AddScoped<ISpeciesService, SpeciesService>();
builder.Services.AddScoped<ITicketsService, TicketsService>();
builder.Services.AddScoped<IBundlesService, BundlesService>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IWorkTasksService, WorkTasksService>();
builder.Services.AddScoped<IPicturesService, PicturesService>();

await builder.Build().RunAsync();
