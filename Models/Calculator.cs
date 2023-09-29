using BudgetTool.Enums;

namespace BudgetTool.Models
{
    public class Calculator
    {
        public int Id { get; set; }
        public decimal LoanBalance { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal InterestRate { get; set; }
        public RepaymentFrequency RepaymentOption { get; set; }
    }
}
