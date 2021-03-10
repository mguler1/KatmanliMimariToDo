using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YSKProje.ToDo.Web.Models
{
    public class AppUserSignInViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Giriniz")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
