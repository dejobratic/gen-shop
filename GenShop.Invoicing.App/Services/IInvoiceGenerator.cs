using GenShop.Invoicing.Domain.Models;
using System.Threading.Tasks;

namespace GenShop.Invoicing.App.Services
{
    public interface IInvoiceGenerator
    {
        Task<Invoice> Generate(Order order);
    }
}
