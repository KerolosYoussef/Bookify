using Bookify.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Extensions;

public static class SeedIdentityDataExtension
{
    public static void SeedIdentityData(this ModelBuilder modelBuilder)
    {
        //a hasher to hash the password before seeding the user to the db
        var hasher = new PasswordHasher<IdentityUser>();
        
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                Name = "Admin"
            },
            new IdentityRole
            {
                Name = "Customer"
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                UserName = "admin@admin.com",
                NormalizedUserName = "MYUSER",
                PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
            }    
        );
        
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210", 
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            }    
        );
    }
}