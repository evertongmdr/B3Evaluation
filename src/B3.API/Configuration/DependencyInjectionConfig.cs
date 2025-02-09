using B3.Application.Interfaces;
using B3.Application.Services;
using B3.Domain.Interfaces.Repositories;
using B3.Infrastructure.Data;
using B3.Infrastructure.Data.Repositories;

namespace B3.API.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();


            #region Repositories

            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IFinancialProductRepository, FinancialProductRepository>();

            #endregion



            #region Services

            services.AddScoped<ICalculateInvestmentService, CalculateInvestmentService>();

            #endregion



        }
    }
}
