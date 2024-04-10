using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResearchProflie.Models;
using ResearchProflie.Services; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Appdatacontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Configure Identity with custom user and role classes.
builder.Services.AddDefaultIdentity<Researcher>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>() // Add support for roles
.AddEntityFrameworkStores<Appdatacontext>();

// Add your custom service registration for P_Register
builder.Services.AddScoped<P_Register>();

// Add your custom service registration for P_Login
builder.Services.AddScoped<P_Login>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Add your custom routes for the Register and Login controllers
app.MapControllerRoute(
    name: "Register",
    pattern: "{controller=Register}/{action=Register}/{id?}");

app.MapControllerRoute(
    name: "Login",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "Publication",
    pattern: "{controller=AddPublication}/{action=CreatePublication}/{id?}");

app.Run();
