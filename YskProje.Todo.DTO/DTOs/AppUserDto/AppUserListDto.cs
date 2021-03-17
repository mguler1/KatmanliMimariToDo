using System;
using System.Collections.Generic;
using System.Text;

namespace YskProje.Todo.DTO.DTOs.AppUserDto
{
   public class AppUserListDto
    {
        public int Id { get; set; }
        //[Display(Name = "Ad")]
        //[Required(ErrorMessage = "Ad Alanı Boş Geçilemez")]
        public string Name { get; set; }
        //[Display(Name = "Soyad")]
        //[Required(ErrorMessage = "SoyAd Alanı Boş Geçilemez")]
        public string SurName { get; set; }
        //[Display(Name = "Email")]
        public string Email { get; set; }
    }
}
