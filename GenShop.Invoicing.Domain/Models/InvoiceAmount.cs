namespace GenShop.Invoicing.Domain.Models
{
    public class InvoiceAmount
    {
        public double Subtotal { get; }
        public double VAT { get; }
        public double VATRate { get; }
        public double Total { get; }

        public InvoiceAmount(
            double subtotal,
            double VATRate)
        {
            Subtotal = subtotal;
            this.VATRate = VATRate;

            VAT = Subtotal * VATRate;
            Total = Subtotal + VAT;
        }
    }
}