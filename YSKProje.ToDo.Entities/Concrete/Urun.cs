using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Interfaces;

namespace YSKProje.ToDo.Entities.Concrete
{
    public class Urun:ITablo
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }

        public List<Gorev> Gorevler { get; set; }
    }
}
