using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewmanMobileApp.Data;
using NewmanMobileApp.Helpers;
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
            ActivityIndicatorStart();
            this.Appearing += QuizPage_Appearing;
            FileProcessor.ReadFile();
            ActivityIndicatorStop();

            }

        private void QuizPage_Appearing(object sender, EventArgs e)
        {

        }

        private void ActivityIndicatorStart()
        {
            indicator.IsEnabled = true;
            indicator.IsRunning = true;
            indicator.IsVisible = true;
        }

        private void ActivityIndicatorStop()
        {
            indicator.IsEnabled = false;
            indicator.IsRunning = false;
            indicator.IsVisible = false;
        }

        public async void QuizStartButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var quizStartedPage = new QuizStartedPage();
                await Navigation.PushAsync(quizStartedPage);



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
                SetNumQuestion();

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

                Environment.Exit(0);
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



        private async void SetNumQuestion()
        {


            string result = await DisplayPromptAsync("SET THE NUMBER OF QUESTIONS TO ASK", "How many questions would you like to answer?", keyboard: Keyboard.Numeric);

            QuizSettings.setNumQuestions = Int32.Parse(result);
            try
            {
                if (QuizSettings.setNumQuestions <= 0)
                {
                    await DisplayAlert("Alert", "Please select a number greater than 0!", "OK");
                    SetNumQuestion();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Something Went Wrong!", "Make sure you are selecting a valid number greater than 0 and try again. Text options are not allowed.", "OK");
            }

        }
    }
}