using GenShop.Invoicing.Domain.Models;

namespace GenShop.Invoicing.Domain.Tests.Unit.Fakes
{
    public static class SupplierMockBuilder
    {
        public static Supplier Build(
            string name = "Gen Shop Supplier #1",
            Address address = null,
            bool paysVat = true)
        {
            return new Supplier(
                name,
                address ?? AddressMockBuilder.BuildGermany(),
                paysVat);
        }
    }
}
