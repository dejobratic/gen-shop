namespace GenShop.Invoicing.Domain.Models.VATRateCalculation
{
    internal class VATPayingSupplierWithNonEUCustomer :
        IVATRateCalculationRule
    {
        public VATRateCalculationResult Execute(
            Supplier supplier, Customer customer)
        {
            if (supplier.PaysVAT && !customer.InEU)
                return VATRateCalculationResult.Success(0);

            return VATRateCalculationResult.Failure();
        }
    }
}
