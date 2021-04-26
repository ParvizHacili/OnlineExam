using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Helpers
{
    public static class EnumerationUtil
    {
        public static void Enumerate(List<SubjectModel> models, int startIndex = 0)
        {
            for (int i = startIndex; i < models.Count; i++)
            {
                var model = models[i];
                model.No = i + 1;
            }
        }
    }
}
