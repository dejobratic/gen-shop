using System;

namespace GenShop.Invoicing.Contract.Requests
{
    public class GetInvoiceRequest :
        IRequest
    {
        public Guid InvoiceId { get; set; }
    }
}
