using System;

namespace GenShop.Invoicing.Contract.Requests
{
    public class GenerateInvoiceRequest :
        IRequest
    {
        public Guid OrderId { get; set; }
    }
}
