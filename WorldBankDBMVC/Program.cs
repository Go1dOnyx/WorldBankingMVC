using WorldBankDB.DataAccess.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WorldBankDB.DataAccess.EF.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

//Add services for authentication and authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie();

//Adds configuration from the appsettings. json file

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables().Build();
builder.Services.AddDbContext<WorldBankDBContext>(
    optionsAction =>
    {
        optionsAction.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection"));
    }
    );

builder.Services.AddIdentity<Users, IdentityRole>()
    .AddEntityFrameworkStores<WorldBankDBContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

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
