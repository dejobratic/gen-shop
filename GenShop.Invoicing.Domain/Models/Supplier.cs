namespace GenShop.Invoicing.Domain.Models
{
    public class Supplier :
        TaxableEntity
    {
        public Supplier(
            string fullName, Address address, bool paysVAT) 
            : base(fullName, address, paysVAT)
        {
        }
    }
}
