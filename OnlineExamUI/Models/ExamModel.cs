using OnlineExamUI.Attributes;
using System;
using OnlineExamUI.ViewModels.UserControls;
using System.Collections.Generic;
using System.Text;
using OnlineExamUI.Helpers;

namespace OnlineExamUI.Models
{
    public class ExamModel : BaseModel
    {

        [Export(Name = "İmtahan Növü")]
        public string ExamType { get; set; }

        [Export(Name = "Qeyd")]
        public string Note { get; set; }

        public ExamModel Clone()
        {
            ExamModel cloneModel = new ExamModel();

            cloneModel.ID = ID;
            cloneModel.No = No;
            cloneModel.ExamType = ExamType;
            cloneModel.Note = Note;

            return cloneModel;
        }

        public bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(ExamType))
            {
                message = UIMessages.GetRequiredMessage("İmtahan Növü");
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
