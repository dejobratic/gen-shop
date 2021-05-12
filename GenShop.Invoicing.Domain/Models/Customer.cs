namespace GenShop.Invoicing.Domain.Models
{
    public class Customer :
        TaxableEntity
    {
        public Customer(
            string fullName, Address address, bool paysVAT)
            : base(fullName, address, paysVAT)
        {
        }
    }
}
