using GenShop.Invoicing.Domain.Models;

namespace GenShop.Invoicing.Domain.Tests.Unit.Fakes
{
    public static class AddressMockBuilder
    {
        public static Address BuildGermany(
            double VATRate = 0.19)
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
                    VATRate = VATRate,
                    InEU = true
                }
            };
        }

        public static Address BuildFrance(
            double VATRate = 0.2)
        {
            return new Address
            {
                StreetLine = "Champs-Élysées",
                City = "Paris",
                PostalCode = "75008",
                Country = new Country
                {
                    Name = "France",
                    Iso2Code = "FR",
                    VATRate = VATRate,
                    InEU = true
                }
            };
        }

        public static Address BuildMontenegro(
            double VATRate = 0.21)
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
                    VATRate = VATRate,
                    InEU = false
                }
            };
        }
    }
}
