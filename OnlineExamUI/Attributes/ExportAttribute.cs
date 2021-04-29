using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Attributes
{ 
    public class ExportAttribute :Attribute
    {
        public int ColumnNo { get; set; }

        public string Name { get; set; }
    }
}
