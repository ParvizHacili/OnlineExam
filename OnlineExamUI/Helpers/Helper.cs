using Exam.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineExamUI.Helpers
{
    public static class Helper
    {
        public static void Log(Exception ex)
        {
            Directory.CreateDirectory(Constants.LOGFILEFOLDER);
            using (var writer = File.AppendText(Constants.LOGFILEPATH))
            {
                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine(ex.ToString());
                writer.WriteLine();
                writer.WriteLine();
            }

        }
    }
}
