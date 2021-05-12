using GenShop.Invoicing.Domain.Kernel;

namespace GenShop.Invoicing.Domain.Models
{
    public class Address :
        ValueObject<Address>
    {
        public string StreetLine { get;  }
        public string City { get;  }
        public string PostalCode { get;  }
        public Country Country { get;  }

        public Address(
            string streetLine, 
            string city, 
            string postalCode, 
            Country country)
        {
            StreetLine = streetLine;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
