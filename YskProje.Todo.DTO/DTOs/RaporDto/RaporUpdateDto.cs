using System;
using System.Collections.Generic;
using System.Text;

namespace YskProje.Todo.DTO.DTOs.RaporDto
{
    public class RaporUpdateDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Tanım Alanı Boş Geçilemez")]
        //[Display(Name = "Tanım")]
        public string Tanim { get; set; }
        //[Required(ErrorMessage = "Detay Alanı Boş Geçilemez")]
        public string Detay { get; set; }
        //public Gorev Gorev { get; set; }
        public int GorevId { get; set; }
    }
}
