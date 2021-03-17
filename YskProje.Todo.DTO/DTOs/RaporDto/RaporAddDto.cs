using System;
using System.Collections.Generic;
using System.Text;

namespace YskProje.Todo.DTO.DTOs.RaporDto
{
   public class RaporAddDto
    {
        
        public string Tanim { get; set; }
        public string Detay { get; set; }
     
        public int GorevId { get; set; }
        //public Gorev Gorev { get; set; }
    }
}
