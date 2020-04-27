using NewmanMobileApp.Data;
using NewmanMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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

        public QuizStartedPage()
        {
            InitializeComponent();
            this.Appearing += QuizStartedPage_Appearing;
            
     
        }

   

        private void QuizStartedPage_Appearing(object sender, EventArgs e)
        {
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
                _radioList.Add(answer);
                Console.WriteLine(" " + num + ": " + answer);
                num = num + 1;
            }



            QuizPage.getAnswerKey = QuizService.answerKey.ToString();
            Debug.WriteLine("ANSWER KEY: " + QuizPage.getAnswerKey);
            var answerPick = new object();

        }


        private void ExitQuizButton_OnClicked(object sender, EventArgs e)
        {
            Console.WriteLine("EXIT BUTTON HIT");
        }

        private void NextQuestionButton_OnClicked(object sender, EventArgs e)
        {
            Console.WriteLine("NEXT BUTTON HIT");
        }

        private void RadioButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("RADIO IS TAPPED!!!");
        }


    }

}