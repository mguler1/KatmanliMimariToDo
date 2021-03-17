using System;
using System.Collections.Generic;
using System.Text;

namespace YskProje.Todo.DTO.DTOs.AppUserDto
{
   public class AppUserSigInDto
    {
       
        public string UserName { get; set; }
       
        public string Password { get; set; }
       
        public bool RememberMe { get; set; }
    }
}
