using GenShop.Invoicing.Domain.Models;

using Contract = GenShop.Invoicing.Contract.Models;

namespace GenShop.Invoicing.App.Extensions
{
    public static class InvoiceExtensions
    {
        public static Contract::Invoice ToContractModel(
            this Invoice invoice)
        {
            return new Contract::Invoice
            {
                Id = invoice.Id,
                Number = invoice.Number,
                CreatedAt = invoice.CreatedAt,
                Issuer = invoice.Supplier.ToContractModel(),
                Receiver = invoice.Customer.ToContractModel(),
                Items = new []
                {
                    invoice.Product.ToContractModel()
                },
                Amount = invoice.Amount.ToContractModel()
            };
        }

        private static Contract::Contact ToContractModel(
            this Supplier supplier)
        {
            return new Contract::Contact
            {
                FullName = supplier.FullName,
                Address = supplier.Address.ToContractModel()
            };
        }

        private static Contract::Contact ToContractModel(
            this Customer customer)
        {
            return new Contract::Contact
            {
                FullName = customer.FullName,
                Address = customer.Address.ToContractModel()
            };
        }

        private static Contract::Address ToContractModel(
            this Address address)
        {
            return new Contract::Address
            {
                StreetLine = address.StreetLine,
                City = address.City,
                PostalCode = address.PostalCode,
                Country = address.Country.Name
            };
        }

        private static Contract::InvoiceItem ToContractModel(
            this Product product)
        {
            return new Contract::InvoiceItem
            {
                Description = product.Description,
                Amount = product.Amount
            };
        }

        private static Contract::InvoiceAmount ToContractModel(
            this InvoiceAmount amount)
        {
            return new Contract::InvoiceAmount
            {
                Total = amount.Total,
                VAT = amount.VAT,
                Subtotal = amount.Subtotal
            };
        }
    }
}
