using Bookify.Interfaces;
using Bookify.Repositories;

namespace Bookify.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            return services;
        }
    }
}
