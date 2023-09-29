using Microsoft.AspNetCore.Mvc;
using BudgetTool.Models;
using BudgetTool.Enums;

namespace BudgetTool.Controllers
{
    public class LoanCalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculator()
        {
            var model = new Calculator
            {
                LoanBalance = 30000,
                MonthlyPayment = 350,
                InterestRate = 6.8,
                RepaymentOption = RepaymentOption.Monthly

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Calculate(Calculator model)
        {
            if (ModelState.IsValid)
            {
                var remainingTerm = CalculateRemainingTerm(model.LoanBalance, model.MonthlyPayment, model.InterestRate);
                var newTerm = CalculateNewTerm(model.LoanBalance, model.MonthlyPayment - model.ExtraPayment, model.InterestRate, model.ExtraPayment);
                var interestSaved = CalculateInterestSaved(model.LoanBalance, model.MonthlyPayment, model.InterestRate, model.ExtraPayment) - CalculateInterestSaved(model.LoanBalance, model.MonthlyPayment - model.ExtraPayment, model.InterestRate, model.ExtraPayment);

                var resultViewModel = new LoanCalculationResultViewModel
                {
                    RemainingTerm = remainingTerm,
                    NewTerm = newTerm,
                    InterestSaved = interestSaved,
                    OriginalMonthlyPayment = model.MonthlyPayment,
                    ExtraPayment = model.ExtraPayment,
                };

                return View("Result", resultViewModel);
            }
            return View("Index", model);
        }
        private int CalculateRemainingTerm(double loanBalance, double monthlyPayment, double annualInterestRate)
        {
            double monthlyInterestRate = annualInterestRate / 12 / 100;
            
            //Math.Log calculates the logarithm, MathCeiling rounds the result up to the nearest whole number
            //Math.Ceiling will represent the term in months after rounding off
           
            double months = Math.Log(monthlyPayment / (monthlyPayment - loanBalance * monthlyInterestRate), 1 + monthlyInterestRate);
            
            int remainingTerm = (int)Math.Ceiling(months);
            return remainingTerm;
        }
        private int CalculateNewTerm(double loanBalance, double monthlyPayment, double extraPayment, double annualInterestRate)
        {
            double monthlyInterestRate = annualInterestRate / 12 / 100;

            double months = Math.Log((monthlyPayment - extraPayment) / ((monthlyPayment - extraPayment) - loanBalance * monthlyInterestRate), 1 + monthlyInterestRate);
            int newTerm = (int)Math.Ceiling(months);
            return newTerm;
        }
        private double CalculateInterestSaved(double loanBalance, double monthlyPayment, double annualInterestRate, double extraPayment)
        {
            double monthlyInterestRate = annualInterestRate / 12 / 100;

            // Calculate the total interest paid without extra payment
            double totalInterestPaidWithoutExtraPayment = 0;
            double remainingBalance = loanBalance;

            while (remainingBalance > 0)
            {
                // Calculate interest for the current month
                double interestPayment = remainingBalance * monthlyInterestRate;

                // Calculate the portion of the payment that goes toward interest
                double interestPortion = Math.Min(interestPayment, remainingBalance);

                // Subtract interest payment from the remaining balance
                remainingBalance -= (monthlyPayment - interestPortion);

                // Accumulate total interest paid
                totalInterestPaidWithoutExtraPayment += interestPayment;
            }

            // Calculate the total interest paid with the extra payment
            double totalInterestPaidWithExtraPayment = 0;
            remainingBalance = loanBalance;

            while (remainingBalance > 0)
            {
                // Calculate interest for the current month
                double interestPayment = remainingBalance * monthlyInterestRate;

                // Calculate the portion of the payment that goes toward interest
                double interestPortion = Math.Min(interestPayment, remainingBalance);

                // Subtract interest payment and extra payment from the remaining balance
                remainingBalance -= (monthlyPayment - interestPortion + extraPayment);

                // Accumulate total interest paid
                totalInterestPaidWithExtraPayment += interestPayment;
            }

            // Calculate interest saved
            double interestSaved = totalInterestPaidWithoutExtraPayment - totalInterestPaidWithExtraPayment;

            return interestSaved;
        }

    }
}
