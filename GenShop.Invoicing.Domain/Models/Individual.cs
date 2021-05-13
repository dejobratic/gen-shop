using System;

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

        public Individual(
            Guid id, 
            string fullName, 
            Address address, 
            bool paysVAT) 
            : base(id, fullName, address, paysVAT)
        {
        }
    }
}
