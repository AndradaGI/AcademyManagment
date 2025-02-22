//using Microsoft.EntityFrameworkCore;
//using AcademyManagement.Models;

//namespace AcademyManagement.Data
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

//        // Constructor fără parametri necesar pentru `dotnet ef`
//        public ApplicationDbContext() { }

//        public DbSet<Academy> Academies { get; set; }
//        public DbSet<Course> Courses { get; set; }
//        public DbSet<Student> Students { get; set; }
//        public DbSet<Enrollment> Enrollments { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AcademyDB;Trusted_Connection=True;");
//            }
//        }
//    }
//}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AcademyManagement.Models;
using AcademyManagment.Models;

namespace AcademyManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // Moștenește IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Constructor fără parametri necesar pentru `dotnet ef`
        public ApplicationDbContext() { }

        // Adaugă tabelele aplicației
        public DbSet<Academy> Academies { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AcademyDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configurare roluri și utilizatori inițiali
            SeedUsersAndRoles(builder);
        }

        private void SeedUsersAndRoles(ModelBuilder builder)
        {
            // Creare rol Admin
            var adminRole = new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            builder.Entity<IdentityRole>().HasData(adminRole);

            // Creare utilizator Admin
            var adminUser = new ApplicationUser
            {
                Id = "100",
                UserName = "admin@demo.com",
                NormalizedUserName = "ADMIN@DEMO.COM",
                Email = "admin@demo.com",
                NormalizedEmail = "ADMIN@DEMO.COM",
                EmailConfirmed = true
            };

            // Setează parola
            var hasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

            builder.Entity<ApplicationUser>().HasData(adminUser);

            // Atribuire rol Admin utilizatorului
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "100"
            });
        }
    }
}
