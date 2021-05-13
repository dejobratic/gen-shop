namespace GenShop.Invoicing.Domain.Models.VATRateCalculation
{
    internal class NonVATPayingSupplier :
        IVATRateCalculationRule
    {
        public VATRateCalculationResult Execute(
            Supplier supplier, Customer customer)
        {
            if (!supplier.PaysVAT)
                return VATRateCalculationResult.Success(0);

            return VATRateCalculationResult.Failure();
        }
    }
}
