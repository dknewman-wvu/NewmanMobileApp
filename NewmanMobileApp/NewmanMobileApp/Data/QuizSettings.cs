using System;
using System.Collections.Generic;
using System.Text;

namespace NewmanMobileApp.Data
{
    class QuizSettings
    {
        public static int setNumQuestions { get; set; } 

        public static string SetPlayerName { get; set; }

        public static string GlobalLogPath { get; set; } = NewmanMobileApp.Helpers.FileProcessor.tempDirectory;

        public static int SetTimeLimit { get; set; } = 0;

        public static string LogName = "QuizLog.txt";

    }


}
