using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.GorevDto;

namespace YskProje.Todo.DTO.DTOs.AppUserDto
{
   public class PersonelGorevlendirListDto
    {
        public AppUserListDto AppUser { get; set; }
        public GorevListDto Gorev { get; set; }
    }
}
