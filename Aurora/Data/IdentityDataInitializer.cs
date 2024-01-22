using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Aurora.Data
{
    public class IdentityDataInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, DataDbContext dbContext)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, dbContext);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Kandydat").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Kandydat",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("PracownikDziekanatu").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "PracownikDziekanatu",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

        }

        public static void SeedOneUser(UserManager<IdentityUser> userManager, string name, string password, string role = null)
        {
            if (userManager.FindByNameAsync(name).Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = name, // musi być taki sam jak email, inaczej nie zadziała
                    Email = name
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded && role != null)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                }
            }
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager, DataDbContext dbContext)
        {
            var hasloPracownik = "pracownik";
            var hasloKandydat = "haslo";

            SeedOneUser(userManager, "admin@pwr", "admin", "Admin");

            dbContext.PracownicyDziekanatu
                .ToListAsync().Result
                .ForEach(p => SeedOneUser(userManager, p.AdresEmail, hasloPracownik, "PracownikDziekanatu"));

            dbContext.Kandydaci
                .ToListAsync().Result
                .ForEach(k => SeedOneUser(userManager, k.AdresEmail, hasloKandydat, "Kandydat"));
        }
    }
}
