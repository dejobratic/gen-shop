namespace GenShop.Invoicing.Contract.Models
{
    public class InvoiceAmount
    {
        public double Subtotal { get; set; }
        public double VAT { get; set; }
        public double Total { get; set; }
    }
}