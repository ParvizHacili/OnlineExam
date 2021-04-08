using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core
{
    public static class Constants
    {
        public static string LOGFILEFOLDER = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\OnlineExam\";

        public static string LOGFILEPATH = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\OnlineExam\log.txt";
    }
}
