using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp
{
    /// <summary>
    /// Represents a quiz with a title and a list of questions.
    /// </summary>
    public class Quiz
    {
        public string Title { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }

    /// <summary>
    /// Represents a question with text, options, correct option index, and weight.
    /// </summary>
    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }
    
    }
}
