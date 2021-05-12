using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Invoice
    {
        public string Number { get; }
        public DateTime CreatedAt { get;  }
        public Supplier Supplier { get;  }
        public Customer Customer { get;  }
        public Product Product { get;  }
        public InvoiceAmount Amount { get; }

        public Invoice(
            Supplier supplier,
            Customer customer,
            Product product)
        {
            Number = Guid.NewGuid().ToString("n");
            CreatedAt = DateTime.UtcNow;
            Supplier = supplier;
            Customer = customer;
            Product = product;
            Amount = CalculateInvoiceAmount();
        }

        private InvoiceAmount CalculateInvoiceAmount()
        {
            var subtotal = Product.Amount;
            var VATRate = CalculateVATRate();

            return new InvoiceAmount(subtotal, VATRate);
        }

        private double CalculateVATRate()
        {
            if (!Supplier.PaysVAT) return 0;

            if (!Customer.InEU) return 0;

            if (Customer.InEU && !Customer.PaysVAT && Customer.Address.Country != Supplier.Address.Country)
                return Customer.Address.Country.VATRate;

            if (Customer.InEU && Customer.PaysVAT && Customer.Address.Country != Supplier.Address.Country)
                return Supplier.Address.Country.VATRate;

            if(Customer.Address.Country == Supplier.Address.Country)
                return Customer.Address.Country.VATRate;

            throw new Exception("Unable to calculate VAT rate.");
        }
    }
}
