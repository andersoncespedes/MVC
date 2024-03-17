
using Application.UnitOfWork;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MVC.Extension;
public static class AppServiceProvider
{
    public static void ServieBinder(this IServiceCollection service)
    {
        service.AddScoped<IUnitOfWork, UnitOfWorks>();
    }
}