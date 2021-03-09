using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YSKProje.ToDo.Web.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Giriniz")]
        [Display(Name="Kullanıcı Adı")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Giriniz")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Parolalar eşleşmiyor")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Compare("Password",ErrorMessage = "E-Posta Giriniz")]
        [EmailAddress(ErrorMessage ="Geçersiz Email Adresi")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ad Giriniz")]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "SoyAd Giriniz")]
        [Display(Name = "SoyAd")]
        public string Surname { get; set; }
    }
}
