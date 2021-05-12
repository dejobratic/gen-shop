namespace GenShop.Invoicing.Domain.Models
{
    public class Product
    {
        public string Description { get; }
        public double Amount { get; }

        public Product(
            string description,
            double amount)
        {
            Description = description;
            Amount = amount;
        }
    }
}
