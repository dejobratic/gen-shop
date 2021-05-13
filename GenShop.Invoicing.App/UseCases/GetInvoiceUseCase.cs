using GenShop.Invoicing.App.Extensions;
using GenShop.Invoicing.App.Repositories;
using GenShop.Invoicing.Contract.Requests;
using GenShop.Invoicing.Domain.Models;
using System.Threading.Tasks;

using Contract = GenShop.Invoicing.Contract.Models;

namespace GenShop.Invoicing.App.UseCases
{
    public class GetInvoiceUseCase :
        ICommand<GetInvoiceRequest, Contract::Invoice>
    {
        private readonly IInvoiceRepository _invoiceRepo;

        public GetInvoiceUseCase(
            IInvoiceRepository invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }

        public async Task<Contract::Invoice> Execute(
            GetInvoiceRequest request)
        {
            Invoice invoice = await _invoiceRepo
                .Get(request.InvoiceId);

            return invoice.ToContractModel();
        }
    }
}
