using GenShop.Invoicing.App.Repositories;
using GenShop.Invoicing.App.Services;
using GenShop.Invoicing.App.UseCases;
using GenShop.Invoicing.Contract.Requests;
using GenShop.Invoicing.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

using Contract = GenShop.Invoicing.Contract.Models;

namespace GenShop.Web.IoC
{
    public static class DependencyModule
    {
        public static void AddDependencies(
            this IServiceCollection services)
        {
            services.AddAppDependencies();
            services.AddDataDependencies();
        }

        public static void AddAppDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<IInvoiceGenerator, InvoiceGenerator>();

            services.AddScoped<
                ICommand<GenerateInvoiceRequest, Contract::Invoice>,
                GenerateInvoiceUseCase>();            
            
            services.AddScoped<
                ICommand<GetInvoiceRequest, Contract::Invoice>,
                GetInvoiceUseCase>();
        }

        public static void AddDataDependencies(
            this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, DummyProductRepository>();
            services.AddSingleton<IOrderRepository, DummyOrderRepository>();
            services.AddSingleton<ISupplierRepository, DummySupplierRepository>();
            services.AddSingleton<ICustomerRepository, DummyCustomerRepository>();
            services.AddSingleton<IInvoiceRepository, DummyInvoiceRepository>();
        }
    }
}
