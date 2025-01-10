using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WorldBankDB.DataAccess.EF.Context;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories;
using WorldBankDB.DataAccess.EF.Services;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using WorldBankDB.DataAccess.EF.Services.Contract;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddControllersAsServices();

//Add services for authentication and authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie();

//DI Container Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

//DI Container Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAddressService, AddressService>();

builder.Services.AddHttpContextAccessor();

//Adds configuration from the appsettings.json file
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables().Build();

//Add DbContext configuration with connection string 
builder.Services.AddDbContext<WorldBankDBContext>(
    optionsAction =>
    {
        optionsAction.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection"));
    }
    );

//Setup Identity system with rules
builder.Services.AddIdentity<Users, IdentityRole>(options =>
    {
        //User Credential Configuration
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 12;
        options.SignIn.RequireConfirmedEmail = false;
        //Lockout Configuration
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
        options.Lockout.AllowedForNewUsers = true;
    })
    .AddEntityFrameworkStores<WorldBankDBContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

var app = builder.Build();

//Configure routing for the Identity API, maps to endpoints
app.MapIdentityApi<Users>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
