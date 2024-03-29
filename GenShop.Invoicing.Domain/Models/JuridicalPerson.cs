﻿using System;

namespace GenShop.Invoicing.Domain.Models
{
    // TODO: consider composition over inheritence; 
    //       need to find out more properties related to juridical person.
    public class JuridicalPerson :
        Customer
    {
        public JuridicalPerson(
            string fullName, 
            Address address, 
            bool paysVAT) 
            : base(fullName, address, paysVAT)
        {
        }

        public JuridicalPerson(
            Guid id, 
            string fullName, 
            Address address, 
            bool paysVAT) 
            : base(id, fullName, address, paysVAT)
        {
        }
    }
}
