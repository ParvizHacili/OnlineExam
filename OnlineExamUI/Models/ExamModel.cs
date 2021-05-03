using OnlineExamUI.Attributes;
using System;
using OnlineExamUI.ViewModels.UserControls;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Models
{
    public  class ExamModel :BaseModel
    {
        [Export(Name = "Fənnin Adı")]
        public SubjectModel SubjectModel { get; set; } 

        public string ExamType { get; set; }

        [Export(Name = "Qeyd")]
        public string Note { get; set; }

        
        public ExamModel Clone()
        {
            ExamModel cloneModel = new ExamModel();

            cloneModel.ID = ID;
            cloneModel.No = No;
            cloneModel.SubjectModel.ID = ID;
            cloneModel.ExamType =ExamType;
            cloneModel.Note = Note;

            return cloneModel;
        }

    }
}
