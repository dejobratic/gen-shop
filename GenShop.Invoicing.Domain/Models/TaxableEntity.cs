using GenShop.Invoicing.Domain.Kernel;
using System;

namespace GenShop.Invoicing.Domain.Models
{
    public abstract class TaxableEntity :
        Entity<Guid>
    {
        public string FullName { get; }
        public Address Address { get; }
        public bool PaysVAT { get; }
        public bool InEU { get; }

        public TaxableEntity(
            string fullName,
            Address address,
            bool paysVAT)
            : this(Guid.NewGuid(), fullName, address, paysVAT)
        {
        }

        public TaxableEntity(
            Guid id,
            string fullName,
            Address address,
            bool paysVAT)
            : base(id)
        {
            Id = id;
            FullName = fullName;
            Address = address;
            PaysVAT = paysVAT;
            InEU = address.Country.InEU;
        }
    }
}
