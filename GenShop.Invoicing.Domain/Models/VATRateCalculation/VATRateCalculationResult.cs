namespace GenShop.Invoicing.Domain.Models.VATRateCalculation
{
    public class VATRateCalculationResult
    {
        public bool IsSuccess { get; }
        public double Value { get; }

        private VATRateCalculationResult(
            bool isSuccess,
            double value)
        {
            IsSuccess = isSuccess;
            Value = value;
        }

        public static VATRateCalculationResult Success(double value)
            => new VATRateCalculationResult(true, value);

        public static VATRateCalculationResult Failure()
            => new VATRateCalculationResult(false, 0);
    }
}
