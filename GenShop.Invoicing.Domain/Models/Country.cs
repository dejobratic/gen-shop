namespace GenShop.Invoicing.Domain.Models
{
    public class Country
    {
        public string Name { get; set; }
        public string Iso2Code { get; set; }
        public double VATRate { get; set; }
        public bool InEU { get; set; }
    }
}
