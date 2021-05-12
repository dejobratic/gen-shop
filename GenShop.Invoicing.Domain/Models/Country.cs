using GenShop.Invoicing.Domain.Kernel;

namespace GenShop.Invoicing.Domain.Models
{
    public class Country :
        ValueObject<Country>
    {
        public string Name { get; }
        public string Iso2Code { get; }
        public double VATRate { get; }
        public bool InEU { get; }

        public Country(
            string name, 
            string iso2Code, 
            double VATRate, 
            bool inEU)
        {
            Name = name;
            Iso2Code = iso2Code;
            this.VATRate = VATRate;
            InEU = inEU;
        }
    }
}
