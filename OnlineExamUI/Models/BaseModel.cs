using Newtonsoft.Json;
using OnlineExamUI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;


namespace OnlineExamUI.Models
{
    public class BaseModel
    { 
        [Export(Name ="№",ColumnNo =0)]
        public int No { get; set; }
        public int ID { get; set; }
    }
}
