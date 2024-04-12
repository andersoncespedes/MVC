using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using MVC.Extension;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ServieBinder();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddDbContext<DBContext>(options => {
    string ? conexion = builder.Configuration.GetConnectionString("SqlServerConn");
    options.UseSqlServer(conexion);
});
builder.Services.AddControllersWithViews(options => {
    new ResponseCacheAttribute
    {
        NoStore = true,
        Location = ResponseCacheLocation.None
    };
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options => {
    options.LoginPath = "/User/Login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=LoginView}/{id?}");

app.Run();
