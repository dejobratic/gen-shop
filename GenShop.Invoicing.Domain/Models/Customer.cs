using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Customer :
        TaxableEntity
    {
        public Customer(
            string fullName, 
            Address address, 
            bool paysVAT)
            : base(fullName, address, paysVAT)
        {
        }

        public Customer(
            Guid id, 
            string fullName, 
            Address address, 
            bool paysVAT) 
            : base(id, fullName, address, paysVAT)
        {
        }
    }
}
