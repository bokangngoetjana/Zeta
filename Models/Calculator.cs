using BudgetTool.Enums;

namespace BudgetTool.Models
{
    public class Calculator
    {
        public int Id { get; set; }
        public double LoanBalance { get; set; }
        public double MonthlyPayment { get; set; }
        public double InterestRate { get; set; }
        public double ExtraPayment { get; set; }
        public RepaymentOption RepaymentOption { get; set; }
    }
}
