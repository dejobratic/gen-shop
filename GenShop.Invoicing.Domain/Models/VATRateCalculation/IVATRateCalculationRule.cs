namespace GenShop.Invoicing.Domain.Models.VATRateCalculation
{
    internal interface IVATRateCalculationRule
    {
        VATRateCalculationResult Execute(Supplier supplier, Customer customer);
    }
}
