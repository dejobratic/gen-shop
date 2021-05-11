namespace GenShop.Invoicing.Domain.Models
{
    public class Customer :
        TaxableEntity
    {
        public Customer(
            string fullName, bool paysVAT)
            : base(fullName, paysVAT)
        {
        }
    }
}
