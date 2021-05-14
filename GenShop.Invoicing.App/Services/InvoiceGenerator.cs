using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Repositories;
using System.Threading.Tasks;

namespace GenShop.Invoicing.App.Services
{
    public class InvoiceGenerator :
        IInvoiceGenerator
    {
        private readonly IProductRepository _productRepo;
        private readonly ISupplierRepository _supplierRepo;
        private readonly ICustomerRepository _customerRepo;

        public InvoiceGenerator(
            IProductRepository productRepo, 
            ISupplierRepository supplierRepo, 
            ICustomerRepository customerRepo)
        {
            _productRepo = productRepo;
            _supplierRepo = supplierRepo;
            _customerRepo = customerRepo;
        }

        public async Task<Invoice> Generate(Order order)
        {
            Product product = await _productRepo
                .Get(order.ProductId);

            Supplier supplier = await _supplierRepo
                .Get(product.SupplierId);

            Customer customer = await _customerRepo
                .Get(order.CustomerId);

            return new Invoice(order, product, supplier, customer);
        }
    }
}
