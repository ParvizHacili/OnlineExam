using OnlineExamUI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Models
{
    public class SubjectModel : BaseModel
    {
        [Export(Name ="Fənnin Adı",ColumnNo =1)]
        public string Name { get; set; }

        public SubjectModel Clone()
        {
            SubjectModel cloneModel = new SubjectModel();

            cloneModel.ID = ID;
            cloneModel.No = No;
            cloneModel.Name =Name;

            return cloneModel;
        }
    }
}
