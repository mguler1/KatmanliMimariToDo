using System;
using System.Collections.Generic;
using System.Text;

namespace YskProje.Todo.DTO.DTOs.GorevDto
{
   public class GorevUpdateDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Lütfen bir ad giriniz")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz")]
        public int AciliyetId { get; set; }
    }
}
