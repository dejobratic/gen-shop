using GenShop.Invoicing.App.Extensions;
using GenShop.Invoicing.App.Services;
using GenShop.Invoicing.Contract.Requests;
using GenShop.Invoicing.Domain.Models;
using System.Threading.Tasks;

using Contract = GenShop.Invoicing.Contract.Models;

namespace GenShop.Invoicing.App.UseCases
{
    public class GenerateInvoiceUseCase :
        ICommand<GenerateInvoiceRequest, Contract::Invoice>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IInvoiceGenerator _invoiceGen;
        private readonly IInvoiceRepository _invoiceRepo;

        public GenerateInvoiceUseCase(
            IOrderRepository orderRepo,
            IInvoiceGenerator invoiceGen,
            IInvoiceRepository invoiceRepo)
        {
            _orderRepo = orderRepo;
            _invoiceGen = invoiceGen;
            _invoiceRepo = invoiceRepo;
        }

        public async Task<Contract::Invoice> Execute(
            GenerateInvoiceRequest request)
        {
            Order order = await _orderRepo
                .Get(request.OrderId);

            Invoice invoice = await Invoice(order);
            return invoice.ToContractModel();
        }

        private async Task<Invoice> Invoice(Order order)
        {
            Invoice invoice = await _invoiceGen.Generate(order);
            await _invoiceRepo.Save(invoice);

            return invoice;
        }
    }
}
