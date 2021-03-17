using System;
using System.Collections.Generic;
using System.Text;

namespace YskProje.Todo.DTO.DTOs.AciliyetDto
{
    public class AciliyetUpdateDto
    {
        public int Id { get; set; }
        //[Display(Name = "Tanım")]
        //[Required(ErrorMessage = "Tanım Alanı Zorunludur")]
        public string Tanim { get; set; }
    }
}
