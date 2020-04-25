using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewmanMobileApp.QuizData;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewmanMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {

        public static List<string> _quiz;
        public static string getAnswerKey;
        public static string answserChosen;
        public static bool isQuizStarted;
        public static string quizFilePath;
        public static string answerChosen;
        public static string sInput;
        public static int questionCount = 1;
        public static int scoreNumOfRight = 0;
        public static int scoreNumOfWrong = 0;
        public static DataQuiz scoreKeeper = new DataQuiz();
        public static Stopwatch stopWatch = new Stopwatch();

        public QuizPage()
        {
            InitializeComponent();
        }


        public async void QuizStartButton_Clicked(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void SetNumberofQuestionsButton_Clicked(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ExitQuizButton_Clicked(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public static void ResetData()
        {
            isQuizStarted = false;
            questionCount = 1;
            scoreNumOfRight = 0;
            scoreNumOfWrong = 0;
            scoreKeeper.numberOfCorrect = 0;
            scoreKeeper.numberOfWrong = 0;
            stopWatch.Reset();
        }

        public static void ShowMenu()
        {

        }
    }
}