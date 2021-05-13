using GenShop.Invoicing.App.UseCases;
using GenShop.Invoicing.Contract.Models;
using GenShop.Invoicing.Contract.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenShop.Web.Controllers
{
    public class GenerateInvoiceController : 
        ControllerBase
    {
        private readonly ICommand<GenerateInvoiceRequest, Invoice> _useCase;

        public GenerateInvoiceController(
            ICommand<GenerateInvoiceRequest, Invoice> useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        [Route("api/invoices")]
        public async Task<IActionResult> GenerateInvoice(
            [FromBody] GenerateInvoiceRequest request)
        {
            var invoice = await _useCase.Execute(request);
            return Ok(invoice);
        }
    }
}
