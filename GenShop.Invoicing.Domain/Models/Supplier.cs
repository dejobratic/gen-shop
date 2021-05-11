namespace GenShop.Invoicing.Domain.Models
{
    public class Supplier :
        TaxableEntity
    {
        public Supplier(
            string fullName, bool paysVAT) 
            : base(fullName, paysVAT)
        {
        }
    }
}
