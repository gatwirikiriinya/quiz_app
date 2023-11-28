using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQuizApp
{
    /// <summary>
    /// Represents the main quiz form.
    /// </summary>
    public partial class QuizForm : Form
    {

        int correctAnswer;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;

        private Quiz currentQuiz;


        // Dictionary to store question weights
        private Dictionary<string, int> questionWeights;

        private HashSet<string> answeredQuestions;


        public QuizForm()
        {
            InitializeComponent();

            // Initialize totalQuestions
            totalQuestions = 5;

            // Initialize question weights
            InitializeQuestionWeights();

            // Store the default button color
            defaultButtonColor = button1.BackColor;

            askQuestion(questionNumber);

            // Initialize the set of answered questions
            answeredQuestions = new HashSet<string>();

        }

        private void InitializeQuestionWeights()
        {
            questionWeights = new Dictionary<string, int>
            {
                { "How did Spider-Man get his powers?", 2 },
                { "What is the longest that an elephant has ever lived? (That we know of)", 5 },
                { "In darts, what's the most points you can score with a single throw?", 4},
                { "How many holes are on a standard bowling ball?", 1 },
                { "Which of these things is NOT located in Africa?", 3 }
            };
        }
        private List<Question> GetQuestions()
        {
            

            return new List<Question>
    {
        new Question
        {
            Text = "How did Spider-Man get his powers?",
            Options = new List<string>
            {
                "Bitten by a radioactive spider",
                "Born with them",
                "Military experiment gone awry",
                "Woke up with them after a strange dream"
            },
            CorrectOptionIndex = 1,
        },
        new Question
        {
            Text = "What is the longest that an elephant has ever lived? (That we know of)",
            Options = new List<string>
            {
                "17 years",
                "49 years",
                "86 years",
                "142 years"
            },
            CorrectOptionIndex = 3,
        },
        new Question
        {
            Text = "In darts, what's the most points you can score with a single throw?",
            Options = new List<string>
            {
                "20",
                "50",
                "60",
                "100"
            },
            CorrectOptionIndex = 3,
        },
        new Question
        {
            Text = "How many holes are on a standard bowling ball?",
            Options = new List<string>
            {
                "2",
                "3",
                "5",
                "10"
            },
            CorrectOptionIndex = 2,
        },
        new Question
        {
            Text = "Which of these things is NOT located in Africa?",
            Options = new List<string>
            {
                "Aswan Dam",
                "Gobi Desert",
                "Lake Victoria",
                "Zambezi River"
            },
            CorrectOptionIndex = 2,
        },
    };
        }

        private void askQuestion(int qnum)
        {
            if (qnum > totalQuestions)
            {
                // Show final score when all questions are answered
                ShowFinalScore();
                return;
            }

            
            currentQuiz = new Quiz
            {
                Title = "General Knowledge",
                Questions = GetQuestions()
            };

           
            Question currentQuestion = currentQuiz.Questions[qnum - 1];

         
            lblQuestion.Text = currentQuestion.Text;

            
            pictureBox1.Image = GetImageForQuestion(currentQuestion.Text);

           
            button1.Text = currentQuestion.Options[0];
            button2.Text = currentQuestion.Options[1];
            button3.Text = currentQuestion.Options[2];
            button4.Text = currentQuestion.Options[3];

            
            correctAnswer = currentQuestion.CorrectOptionIndex;
        }


        private void ShowFinalScore()
        {
            int totalWeightedScore = questionWeights.Sum(q => q.Value); // Calculate the total possible weighted score

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(
                "Quiz Ended" + Environment.NewLine +
                $"You have answered {answeredQuestions.Count} questions correctly out of {totalQuestions}." + Environment.NewLine +
                $"Your total percentage is {(double)answeredQuestions.Count / totalQuestions * 100:F2}%." + Environment.NewLine +
                $"Your total weighted score is {score} out of {totalWeightedScore} (weighted score)." + Environment.NewLine +
                "Do you want to play again?",
                "Quiz Result",
                buttons);

            if (result == DialogResult.Yes)
            {
                // User clicked Yes, so reset the quiz
                score = 0;
                questionNumber = 1;

                // Clear the set of answered questions for the next quiz
                answeredQuestions.Clear();

                // Ask the first question of the next quiz
                askQuestion(questionNumber);
            }
            else
            {
                
                MessageBox.Show("Thank you for playing!");
                this.Close(); // Close the form or exit the application
            }
        }


        private async void checkAnswerEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);

            // Check if the answer is correct
            bool isCorrect = buttonTag == correctAnswer;

            // Change button color based on correctness
            senderObject.BackColor = isCorrect ? Color.Green : Color.Red;

            // Increment score based on question weight if correct and not already answered
            if (isCorrect && answeredQuestions.Add(lblQuestion.Text))
            {
                score += questionWeights[lblQuestion.Text];
            }

            // Delay for 1 seconds to show the color change
            await Task.Delay(1000);

            // Reset button colors
            ResetButtonColors();


            if (questionNumber == totalQuestions)
            {
                // Show final score when all questions are answered
                ShowFinalScore();
                return;
            }

            // Reset button colors before moving to the next question
            ResetButtonColors();

            // Move on to the next question
            questionNumber++;
            askQuestion(questionNumber);
        }

 

        // Method to reset button colors to default
        private void ResetButtonColors()
        {
            button1.BackColor = defaultButtonColor;
            button2.BackColor = defaultButtonColor;
            button3.BackColor = defaultButtonColor;
            button4.BackColor = defaultButtonColor;
        }

        // Add a field to store the default button color
        private Color defaultButtonColor;
        private System.Drawing.Image GetImageForQuestion(string questionText)
        {

            if (questionText.Contains("Spider-Man"))
            {
                return Properties.Resources.spiderman;
            }
            if (questionText.Contains("elephant"))
            {
                return Properties.Resources.elephant;
            }
            if (questionText.Contains("bowling"))
            {
                return Properties.Resources.balls;
            }
            if (questionText.Contains("Africa"))
            {
                return Properties.Resources.africa;
            }
            if (questionText.Contains("darts"))
            {
                return Properties.Resources.darts;
            }

            return null;
        }


    }
}
