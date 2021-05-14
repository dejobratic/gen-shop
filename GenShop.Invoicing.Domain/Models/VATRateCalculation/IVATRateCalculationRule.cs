namespace GenShop.Invoicing.Domain.Models.VATRateCalculation
{
    public interface IVATRateCalculationRule
    {
        VATRateCalculationResult Execute(Supplier supplier, Customer customer);
    }
}
