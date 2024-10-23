using WorldBankDB.DataAccess.EF.Context;
using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

//Add services for authentication and authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie();

//DI Container Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

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
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 12;
        options.SignIn.RequireConfirmedEmail = false;
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
