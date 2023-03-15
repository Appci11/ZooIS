global using Microsoft.EntityFrameworkCore;
global using ZooIS.Server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using ZooIS.Server.Services.AnimalsService;
using ZooIS.Server.Services.AreasService;
using ZooIS.Server.Services.BundlesService;
using ZooIS.Server.Services.EmployeesService;
using ZooIS.Server.Services.HabitatsService;
using ZooIS.Server.Services.AuthService;
using ZooIS.Server.Services.SpeciesService;
using ZooIS.Server.Services.TagsService;
using ZooIS.Server.Services.TicketsService;
using ZooIS.Server.Services.UserSettingsService;
using ZooIS.Server.Services.UsersService;
using ZooIS.Server.Services.WorkTasksService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserSettingsService,UserSettingsService>();
builder.Services.AddScoped<ITicketsService, TicketsService>();
builder.Services.AddScoped<IBundlesService, BundlesService>();
builder.Services.AddScoped<IWorkTasksService, WorkTasksService>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IAreasService, AreasService>();
builder.Services.AddScoped<ITagsService, TagsService>();
builder.Services.AddScoped<IHabitatsService, HabitatsService>();
builder.Services.AddScoped<ISpeciesService, SpeciesService>();
builder.Services.AddScoped<IAnimalsService, AnimalsService>();

//swagger thingies start
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Auth header, using Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
//swagger thingies end

builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1", builder =>
     builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    //add swagger start
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
    });
    //add swagger end
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("Policy1");
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.Map("api/{**slug}", HandleApiFallback);
    endpoints.MapFallbackToFile("{**slug}", "index.html");
});

// tam, kad api call'ai nemestu html'o
// didesniems projektas logiskiau naudot reverse proxy
Task HandleApiFallback(HttpContext context)
{
    context.Response.StatusCode = StatusCodes.Status404NotFound;
    return Task.CompletedTask;
}

app.MapFallbackToFile("index.html");

app.Run();
