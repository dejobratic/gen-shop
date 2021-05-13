using GenShop.Invoicing.Domain.Kernel;
using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class InvoiceAmount :
        ValueObject<InvoiceAmount>
    {
        public double Subtotal { get; }
        public double VAT { get; }
        public double VATRate { get; }
        public double Total { get; }

        public InvoiceAmount(
            double subtotal,
            double VATRate)
        {
            Subtotal = RoundToTwoDecimals(subtotal);
            this.VATRate = RoundToTwoDecimals(VATRate);

            VAT = RoundToTwoDecimals(Subtotal * VATRate);
            Total = RoundToTwoDecimals(Subtotal + VAT);
        }

        private static double RoundToTwoDecimals(double number)
            => Math.Round(number, 2);
    }
}