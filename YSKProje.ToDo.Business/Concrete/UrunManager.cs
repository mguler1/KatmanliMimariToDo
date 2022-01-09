using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class UrunManager : IUrunService
    {
        private readonly IUrunDal _urumDal;
        public UrunManager(IUrunDal urumDal)
        {
            _urumDal = urumDal;
        }
        public List<Urun> GetirHepsi()
        {
            return _urumDal.GetirHepsi();
        }

        public Urun GetirIdile(int id)
        {
            return _urumDal.GetirIdile(id);
        }

        public void Guncelle(Urun tablo)
        {
            _urumDal.Guncelle(tablo);
        }

        public void Kaydet(Urun tablo)
        {
            _urumDal.Kaydet(tablo);
        }

        public void Sil(Urun tablo)
        {
            _urumDal.Sil(tablo);
        }
    }
}
