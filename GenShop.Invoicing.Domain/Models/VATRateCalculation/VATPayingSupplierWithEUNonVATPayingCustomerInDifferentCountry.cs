namespace GenShop.Invoicing.Domain.Models.VATRateCalculation
{
    public class VATPayingSupplierWithEUNonVATPayingCustomerInDifferentCountry :
        IVATRateCalculationRule
    {
        public VATRateCalculationResult Execute(
            Supplier supplier, Customer customer)
        {
            if (supplier.PaysVAT && customer.InEU && !customer.PaysVAT
                && customer.Address.Country != supplier.Address.Country)
            {
                var value = customer.Address.Country.VATRate;
                return VATRateCalculationResult.Success(value);
            }

            return VATRateCalculationResult.Failure();
        }
    }
}
