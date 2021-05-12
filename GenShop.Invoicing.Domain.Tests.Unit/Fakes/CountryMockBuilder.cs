using GenShop.Invoicing.Domain.Models;

namespace GenShop.Invoicing.Domain.Tests.Unit.Fakes
{
    public static class CountryMockBuilder
    {
        public static Country BuildGermany(
            double VATRate = 0.19)
        {
            return Build("Germany", "DE", VATRate, true);
        }

        public static Country BuildFrance(
            double VATRate = 0.2)
        {
            return Build("France", "FR", VATRate, true);
        }

        public static Country BuildMontenegro(
            double VATRate = 0.21)
        {
            return Build("Montenegro", "ME", VATRate, false);
        }

        private static Country Build(
            string name,
            string iso2Code,
            double VATRate,
            bool inEU)
        {
            return new Country(name, iso2Code, VATRate, inEU);
        }
    }
}
