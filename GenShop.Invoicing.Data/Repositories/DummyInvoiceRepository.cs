using GenShop.Invoicing.App.Repositories;
using GenShop.Invoicing.Domain.Exceptions;
using GenShop.Invoicing.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GenShop.Invoicing.Data.Repositories
{
    public class DummyInvoiceRepository :
        BaseRepository<Invoice>,
        IInvoiceRepository
    {
        public override Task Save(Invoice invoice)
        {
            if(_cache.ContainsKey(invoice.Id))
            {
                _cache[invoice.Id] = invoice;
                return Task.CompletedTask;
            }

            var existing = _cache.Values
                .Where(i => i.Order.Id == invoice.Order.Id)
                .SingleOrDefault();

            if (existing is { })
                throw new EntityAlreadyExistsException(typeof(Invoice));

            _cache.Add(invoice.Id, invoice);
            return Task.CompletedTask;
        }
    }
}
