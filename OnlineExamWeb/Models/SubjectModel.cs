using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Models
{
    public class SubjectModel :BaseModel
    {
        [Required(ErrorMessage ="Fənnin adı mütləq daxil edilməlidir!")]
        [StringLength(50,ErrorMessage ="Fənnin adı 50 simvoldan çox ola bilməz!")]
        public string Name { get; set; }
    }
}
