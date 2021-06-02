using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Models
{
    public class ExamModel : BaseModel
    {
        [Required(ErrorMessage = "Imtahan növü mütləq daxil edilməlidir!")]
        [StringLength(50, ErrorMessage = "Imtahan növü 50 simvoldan çox ola bilməz!")]
        public string ExamType { get; set; }

        public string Note { get; set; }
    }
}
