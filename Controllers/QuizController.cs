using Microsoft.AspNetCore.Mvc;
using BudgetTool.Models;
using BudgetTool.Data;
using Microsoft.AspNetCore.Authorization;

namespace BudgetTool.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private List<Question> _questions;

        public QuizController()
        {
            _questions = new List<Question>
                {
                    new Question
                    {
                        Id = 1,
                        Text = "What is the most effective way to save money?",
                        Choices = new List<string> { "Set Goal", "Madrid", "Paris", "Rome" },
                        CorrectChoiceIndex = 2 // Paris
                    },
                     new Question
            {
                Id = 2,
                Text = "Which planet is known as the Red Planet?",
                Choices = new List<string> { "Earth", "Mars", "Venus", "Jupiter" },
                CorrectChoiceIndex = 1 // Mars
            },
                };
        }

        public IActionResult Index()
        {
            //List<Question> questions = LoadQuestionsFromSomeSource(); // Replace with actual data loading logic
            return View();
        }

        [HttpPost]
        public IActionResult SubmitQuiz(List<int> selectedAnswers)
        {
            int score = CalculateScore(selectedAnswers);
            ViewBag.Score = score;
            return View("QuizResult");
        }
        private int CalculateScore(List<int> selectedAnswers)
        {
            int score = 0;
            for (int i = 0; i < _questions.Count; i++)
            {
                if (selectedAnswers[i] == _questions[i].CorrectChoiceIndex)
                {
                    score++;
                }
            }
            return score;
        }

    }
}
