namespace GenShop.Invoicing.Domain.Models
{
    public abstract class TaxableEntity
    {
        public string FullName { get; }
        public bool PaysVAT { get; }

        public TaxableEntity(
            string fullName,
            bool paysVAT)
        {
            FullName = fullName;
            PaysVAT = paysVAT;
        }
    }
}
