namespace GenShop.Invoicing.Domain.Models
{
    // TODO: consider composition over inheritence; 
    //       need to find out more properties related to individual.
    public class Individual :
        Customer
    {
        public Individual(
            string fullName, Address address, bool paysVAT) 
            : base(fullName, address, paysVAT)
        {
        }
    }
}
