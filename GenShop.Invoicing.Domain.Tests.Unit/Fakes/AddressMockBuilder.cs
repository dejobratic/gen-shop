using GenShop.Invoicing.Domain.Models;

namespace GenShop.Invoicing.Domain.Tests.Unit.Fakes
{
    public static class AddressMockBuilder
    {
        public static Address BuildGermany(
            double VATRate = 0.19)
        {
            return Build(
                "Hermanstrasse 35a",
                "Augsburg",
                "86154",
                CountryMockBuilder.BuildGermany(VATRate));
        }

        public static Address BuildFrance(
            double VATRate = 0.2)
        {
            return Build(
                "Champs-Élysées",
                "Paris",
                "75008",
                CountryMockBuilder.BuildFrance(VATRate));
        }

        public static Address BuildMontenegro(
            double VATRate = 0.21)
        {
            return Build(
                "Cetinjski put bb",
                "Podgorica",
                "81000",
                CountryMockBuilder.BuildMontenegro(VATRate));
        }

        private static Address Build(
            string streetLine,
            string city,
            string postalCode,
            Country country)
        {
            return new Address(
                streetLine,
                city,
                postalCode,
                country);
        }
    }
}
