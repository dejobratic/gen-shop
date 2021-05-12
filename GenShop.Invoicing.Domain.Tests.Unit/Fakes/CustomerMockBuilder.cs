using GenShop.Invoicing.Domain.Models;

namespace GenShop.Invoicing.Domain.Tests.Unit.Fakes
{
    public static class CustomerMockBuilder
    {
        public static Customer Build(
            string name = "John Smith",
            Address address = null,
            bool paysVat = true)
        {
            return new Customer(
                name,
                address ?? AddressMockBuilder.BuildGermany(),
                paysVat);
        }
    }
}
