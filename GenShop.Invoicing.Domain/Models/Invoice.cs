using GenShop.Invoicing.Domain.Helpers;
using GenShop.Invoicing.Domain.Kernel;
using GenShop.Invoicing.Domain.Models.VATRateCalculation;
using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Invoice :
        Entity<Guid>
    {
        private static readonly IVATRateCalculationRule[] _VATRateCalculationRules =
            Loader.LoadAllInterfaceImplementations<IVATRateCalculationRule>();

        public string Number { get; }
        public DateTime CreatedAt { get; }
        public Order Order { get; }
        public Supplier Supplier { get; }
        public Customer Customer { get; }
        public Product Product { get; }
        public InvoiceAmount Amount { get; }

        public Invoice(
            Order order,
            Product product,
            Supplier supplier,
            Customer customer)
            : this(
                  Guid.NewGuid(),
                  Guid.NewGuid().ToString("n"),
                  DateTime.UtcNow,
                  order,
                  product,
                  supplier,
                  customer,
                  CalculateInvoiceAmount(product, supplier, customer))
        {
        }

        public Invoice(
            Guid id,
            string number,
            DateTime createdAt,
            Order order,
            Product product,
            Supplier supplier,
            Customer customer,
            InvoiceAmount amount)
            : base(id)
        {
            Number = number;
            CreatedAt = createdAt;
            Order = order;
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
            foreach (var rule in _VATRateCalculationRules)
            {
                var result = rule.Execute(supplier, customer);
                if (result.IsSuccess) return result.Value;
            }

            throw new Exception("Unable to calculate VAT rate.");
        }
    }
}
