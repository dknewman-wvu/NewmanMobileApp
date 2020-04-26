using NewmanMobileApp.Data;
using NewmanMobileApp.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewmanMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizStartedPage : ContentPage
    {
        public QuizStartedPage()
        {
            InitializeComponent();
            this.Appearing += QuizStartedPage_Appearing;
        }

        private void QuizStartedPage_Appearing(object sender, EventArgs e)
        {
            QuestionsLabel.Text = GenerateQuestions();
        }


        public static void StartQuiz()
        {
            if (QuizPage.questionCount <= QuizSettings.setNumQuestions)
            {

                GenerateQuestions();
                GenerateAnswers();
                //QuizLogic();
            }
            else
            {
                

                Console.WriteLine("Game Over\n");
                System.Threading.Thread.Sleep(3500);
              //  ResetData();
                Console.Clear();
                //ShowMenu();

            }
        }

        private static void QuizLogic()
        {
            QuizPage.answerChosen = Console.ReadLine();
            if (QuizPage.getAnswerKey == QuizPage.answerChosen)
            {
                Console.WriteLine("CORRECT!");
                QuizPage.scoreNumOfRight = QuizPage.scoreNumOfRight + 1;
                QuizPage.scoreKeeper.numberOfCorrect = QuizPage.scoreNumOfRight;
                QuizPage.questionCount = QuizPage.questionCount + 1;
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                // GenerateQuiz();
            }
            else
            {
                if (QuizPage.answerChosen.ToUpper() == "EXIT")
                {
                    QuizPage.isQuizStarted = false;
                    Console.Clear();
                    //  ShowMenu();
                }
                else
                {
                    Console.WriteLine("SORRY THAT IS INCORRECT!");
                    QuizPage.scoreNumOfWrong = QuizPage.scoreNumOfWrong + 1;
                    QuizPage.scoreKeeper.numberOfWrong = QuizPage.scoreNumOfWrong;
                    QuizPage.questionCount = QuizPage.questionCount + 1;
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    //   GenerateQuiz();
                }
            }
        }


        public static string GenerateQuestions()
        {
            Console.WriteLine("Question");
            QuizService.SetQuizQuestions();
            string newQuestion = QuizService.question.Trim();
            var nextQuestion = (Regex.Replace(newQuestion, "^[0-9]+", string.Empty) + "\n");
            QuizPage.isQuizStarted = true;


            return nextQuestion;


        }

        public static void GenerateAnswers()
        {


            int num = 1;

            foreach (string answer in QuizService.answer.Skip(1))
            {
                Console.WriteLine(" " + num + ": " + answer);
                num = num + 1;
            }

            Console.WriteLine("\n");
            Console.WriteLine("Please select your answer or type EXIT to quit.");

            QuizPage.getAnswerKey = QuizService.answerKey.ToString();
            Debug.WriteLine("ANSWER KEY: " + QuizPage.getAnswerKey);
            var answerPick = new object();

        }




    }

}