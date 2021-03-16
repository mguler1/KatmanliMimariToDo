using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.Areas.Admin.Models
{
    public class RaporUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tanım Alanı Boş Geçilemez")]
        [Display(Name = "Tanım")]
        public string Tanim { get; set; }
        [Required(ErrorMessage = "Detay Alanı Boş Geçilemez")]
        public string Detay { get; set; }
        public Gorev Gorev { get; set; }
        public int GorevId { get; set; }
    }
}
