using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YSKProje.ToDo.Web.Areas.Admin.Models
{
    public class RaporAddViewModel
    {
        [Required(ErrorMessage ="Tanım Alanı Boş Geçilemez")]
        [Display(Name ="Tanım")]
        public string Tanim { get; set; }
        [Required(ErrorMessage = "Detay Alanı Boş Geçilemez")]
        public string Detay { get; set; }
        public int GorevId { get; set; }
    }
}
