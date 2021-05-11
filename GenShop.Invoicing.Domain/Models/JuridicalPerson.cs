namespace GenShop.Invoicing.Domain.Models
{
    // TODO: consider composition over inheritence; 
    //       need to find out more properties related to juridical person.
    public class JuridicalPerson :
        Customer
    {
        public JuridicalPerson(
            string fullName, bool paysVAT) 
            : base(fullName, paysVAT)
        {
        }
    }
}
