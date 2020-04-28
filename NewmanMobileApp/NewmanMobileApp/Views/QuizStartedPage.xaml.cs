using NewmanMobileApp.Data;
using NewmanMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.Net.Wifi.Aware;
using Plugin.InputKit.Shared.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewmanMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizStartedPage : ContentPage
    {

        public RadioButton radioButton;
        private static List<string> _radioList;
        public static string setAnswerChosen { get; set; }
        private static int viewCount { get; set; } = 0;

        public QuizStartedPage()
        {
            InitializeComponent();
            this.Appearing += QuizStartedPage_Appearing;


        }


        private void QuizStartedPage_Appearing(object sender, EventArgs e)
        {
            GetNewQa();
        }

        private void GetNewQa()
        {
            if (_radioList != null)
            {
                _radioList.Clear();
            }

            _radioList = new List<string>();

            QuestionsLabel.Text = GenerateQuestions();

            GenerateAnswers();

            RadioGrid.Children.Add(AnswerButtonsGroup, 0, 1);
            foreach (var radioItem in _radioList)
            {
                radioButton = new RadioButton();
                radioButton.Text = radioItem;
                AnswerButtonsGroup.Children.Add(radioButton);
                radioButton.Clicked += RadioButton_Clicked;
            }

          
            Console.WriteLine("Break");
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

        private async void QuizLogic()
        {
            if (QuizPage.getAnswerKey == setAnswerChosen)
            {
                await DisplayAlert("Correct!", "Way to go!", "OK");

                // GenerateQuiz();
            }
            else
            {

                await DisplayAlert("Sorry!", "Sorry that was incorrect, try again...", "OK");

                //   GenerateQuiz();

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
                _radioList.Add(answer);
                Console.WriteLine(" " + num + ": " + answer);
                num = num + 1;
            }



            QuizPage.getAnswerKey = QuizService.answerKey.ToString();
            Debug.WriteLine("ANSWER KEY: " + QuizPage.getAnswerKey);
            var answerPick = new object();

        }


        private async void ExitQuizButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void NextQuestionButton_OnClicked(object sender, EventArgs e)
        {


            AnswerButtonsGroup.Children.Clear();
           // RadioGrid.Children.Remove(AnswerButtonsGroup);

            await Task.Delay(100);

            GetNewQa();






        }

        private void RadioButton_Clicked(object sender, EventArgs e)
        {
            int answerIndexIncrement = AnswerButtonsGroup.SelectedIndex;
            int selectedAnswer = (1 + answerIndexIncrement);
            setAnswerChosen = selectedAnswer.ToString();

            QuizLogic();
        }


    }

}