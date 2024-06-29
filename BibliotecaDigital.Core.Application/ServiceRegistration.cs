using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BibliotecaDigital.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IAutorService, AutorService>();
            #endregion
        }
    }
}
