using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Supplier :
        TaxableEntity
    {
        public Supplier(
            string fullName, 
            Address address, 
            bool paysVAT) 
            : base(fullName, address, paysVAT)
        {
        }

        public Supplier(
            Guid id, 
            string fullName, 
            Address address, 
            bool paysVAT) 
            : base(id, fullName, address, paysVAT)
        {
        }
    }
}
