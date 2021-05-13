using GenShop.Invoicing.Domain.Kernel;

namespace GenShop.Invoicing.Domain.Models
{
    public class Contact :
        ValueObject<Contact>
    {
        public string FullName { get; }
        public Address Address { get; }

        public Contact(
            string fullName, Address address)
        {
            FullName = fullName;
            Address = address;
        }
    }
}
