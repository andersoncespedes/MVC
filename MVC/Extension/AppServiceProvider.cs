
using Application.UnitOfWork;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Identity;
using MVC.Services;

namespace MVC.Extension;
public static class AppServiceProvider
{
    public static void ServieBinder(this IServiceCollection service)
    {
        service.AddScoped<IUnitOfWork, UnitOfWorks>();
        service.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
        service.AddScoped<IUserService, UserService>();
    }
}