using Microsoft.AspNetCore.Identity;

namespace WorldBankDBMVC
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider) 
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roles = { "Admin", "Moderator","User" };

            foreach(var role in roles) 
            {
                if (!await roleManager.RoleExistsAsync(role)) 
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
