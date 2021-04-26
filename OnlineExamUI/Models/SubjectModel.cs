using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Models
{
    public class SubjectModel : BaseModel
    {
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
