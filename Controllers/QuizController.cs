using Microsoft.AspNetCore.Mvc;
using BudgetTool.Models;
using BudgetTool.Data;

namespace BudgetTool.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
