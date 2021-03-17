using System;
using System.Collections.Generic;
using System.Text;

namespace YskProje.Todo.DTO.DTOs.AppUserDto
{
   public class AppUserSigInDto
    {
        //[Required(ErrorMessage = "Kullanıcı Adı Giriniz")]
        //[Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Şifre Giriniz")]
        //[Display(Name = "Şifre")]
        public string Password { get; set; }
        //[Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
