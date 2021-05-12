using GenShop.Invoicing.Domain.Models;

namespace GenShop.Invoicing.Domain.Tests.Unit.Fakes
{
    public static class AddressMockBuilder
    {
        public static Address BuildGermany()
        {
            return new Address
            {
                StreetLine = "Hermanstrasse 35a",
                City = "Augsburg",
                PostalCode = "86154",
                Country = new Country
                {
                    Name = "Germany",
                    Iso2Code = "DE",
                    VATRate = 0.19,
                    IsInEU = true
                }
            };
        }

        public static Address BuildMontenegro()
        {
            return new Address
            {
                StreetLine = "Cetinjski put bb",
                City = "Podgorica",
                PostalCode = "81000",
                Country = new Country
                {
                    Name = "Montenegro",
                    Iso2Code = "ME",
                    VATRate = 0.21,
                    IsInEU = false
                }
            };
        }
    }
}
