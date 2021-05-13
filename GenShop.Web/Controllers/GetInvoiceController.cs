using GenShop.Invoicing.App.UseCases;
using GenShop.Invoicing.Contract.Models;
using GenShop.Invoicing.Contract.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GenShop.Web.Controllers
{
    public class GetInvoiceController : 
        ControllerBase
    {
        private readonly ICommand<GetInvoiceRequest, Invoice> _useCase;

        public GetInvoiceController(
            ICommand<GetInvoiceRequest, Invoice> useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        [Route("api/invoices/{id}")]
        public async Task<IActionResult> GenerateInvoice(
            [FromRoute] Guid id)
        {
            var request = new GetInvoiceRequest { InvoiceId = id };

            var invoice = await _useCase.Execute(request);
            return Ok(invoice);
        }
    }
}
