namespace BudgetTool.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<QuizQuestion>? Questions { get; set;  }
        //public int CorrectAnswerCounter { get; set; }

        //public int EducationalContentId { get; set; }
        //public EducationalContent educationalContent { get; set; }
    }
    public class QuizOption
    {
        public int Id { get; set; }
        public string OptionText { get; set; }
    }
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectOption { get; set; }

    }
}
