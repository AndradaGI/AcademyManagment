//using AcademyManagement.Data;
//using AcademyManagment.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Adaugă conexiunea la baza de date
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddControllersWithViews(options =>
//{
//    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter());
//});

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
//{
//    options.Password.RequiredLength = 8;
//    options.Password.RequireNonAlphanumeric = true;

//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
//    options.Lockout.MaxFailedAccessAttempts = 3;
//})
//.AddEntityFrameworkStores<ApplicationDbContext>()
//.AddDefaultTokenProviders();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Account/Login";
//    options.AccessDeniedPath = "/Account/AccessDenied";
//});

//var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();
//app.UseAuthentication(); 

//// Rutele aplicației
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Account}/{action=Login}/{id?}");

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var context = services.GetRequiredService<ApplicationDbContext>();
//    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//    DbInitializer.Initialize(context);
//    //await CreateDefaultUser(userManager, roleManager);
//}

//app.UseSwagger();
//app.UseSwaggerUI();

//app.MapControllers();
//app.Run();

//// Metodă pentru a crea un utilizator predefinit la pornirea aplicației
//async Task CreateDefaultUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
//{
//    string email = "admin@demo.com";
//    string password = "Admin@123";

//    if (await userManager.FindByEmailAsync(email) == null)
//    {
//        var user = new ApplicationUser
//        {
//            UserName = email,
//            Email = email,
//            EmailConfirmed = true
//        };

//        var result = await userManager.CreateAsync(user, password);
//        if (result.Succeeded)
//        {
//            Console.WriteLine($"Utilizatorul {email} a fost creat cu succes!");
//        }
//        else
//        {
//            Console.WriteLine("Eroare la crearea utilizatorului: " + string.Join(", ", result.Errors.Select(e => e.Description)));
//        }
//    }
//}

using AcademyManagement.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adaugă conexiunea la baza de date
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Academies}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    DbInitializer.Initialize(context);
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
