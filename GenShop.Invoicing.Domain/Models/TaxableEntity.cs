namespace GenShop.Invoicing.Domain.Models
{
    public abstract class TaxableEntity
    {
        public string FullName { get; }
        public Address Address { get; }
        public bool PaysVAT { get; }

        public TaxableEntity(
            string fullName,
            Address address,
            bool paysVAT)
        {
            FullName = fullName;
            Address = address;
            PaysVAT = paysVAT;
        }
    }
}
