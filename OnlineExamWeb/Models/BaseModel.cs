using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Models
{
    public abstract class BaseModel
    {
        public int ID { get; set; }

        public int No { get; set; }
    }
}
