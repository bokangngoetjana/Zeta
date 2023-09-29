using Microsoft.AspNetCore.Mvc;

namespace BudgetTool.Controllers
{
    public class LoanCalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
