using GenShop.Invoicing.Domain.Models;

namespace GenShop.Invoicing.App.Services
{
    public interface IInvoiceRepository :
        IRepository<Invoice>
    {
    }
}
