namespace BudgetTool.Models
{
    public class LoanCalculationResultViewModel
    {
        public int RemainingTerm { get; set; }
        public int NewTerm { get; set; }
        public double InterestSaved { get; set; }
        public double OriginalMonthlyPayment { get; set; }
        public double ExtraPayment { get; set; }
    }
}
