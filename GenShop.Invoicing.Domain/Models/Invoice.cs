using GenShop.Invoicing.Domain.Kernel;
using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Invoice :
        Entity<Guid>
    {
        public string Number { get; }
        public DateTime CreatedAt { get; }
        public Supplier Supplier { get; }
        public Customer Customer { get; }
        public Product Product { get; }
        public InvoiceAmount Amount { get; }

        public Invoice(
            Supplier supplier,
            Customer customer,
            Product product)
            : this(
                  Guid.NewGuid(),
                  Guid.NewGuid().ToString("n"),
                  DateTime.UtcNow,
                  supplier,
                  customer,
                  product,
                  CalculateInvoiceAmount(product, supplier, customer))
        {
        }

        public Invoice(
            Guid id,
            string number,
            DateTime createdAt,
            Supplier supplier,
            Customer customer,
            Product product,
            InvoiceAmount amount)
            : base(id)
        {
            Number = number;
            CreatedAt = createdAt;
            Supplier = supplier;
            Customer = customer;
            Product = product;
            Amount = amount;
        }

        private static InvoiceAmount CalculateInvoiceAmount(
            Product product,
            Supplier supplier,
            Customer customer)
        {
            var subtotal = product.Amount;
            var VATRate = CalculateVATRate(supplier, customer);

            return new InvoiceAmount(subtotal, VATRate);
        }

        private static double CalculateVATRate(
            Supplier supplier, Customer customer)
        {
            if (!supplier.PaysVAT)
                return 0;

            if (!customer.InEU)
                return 0;

            if (customer.InEU && !customer.PaysVAT && customer.Address.Country != supplier.Address.Country)
                return customer.Address.Country.VATRate;

            if (customer.InEU && customer.PaysVAT && customer.Address.Country != supplier.Address.Country)
                return supplier.Address.Country.VATRate;

            if (customer.Address.Country == supplier.Address.Country)
                return customer.Address.Country.VATRate;

            throw new Exception("Unable to calculate VAT rate.");
        }
    }
}
