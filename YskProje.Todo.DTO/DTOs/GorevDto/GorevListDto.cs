﻿using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YskProje.Todo.DTO.DTOs.GorevDto
{
   public class GorevListDto
    {
        public int Id { get; set; }

        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime OlusturulmaTarih { get; set; }

        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        public int AciliyetId { get; set; }
        public Aciliyet Aciliyet { get; set; }
    }
}
