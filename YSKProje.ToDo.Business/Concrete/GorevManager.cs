using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class GorevManager : IGorevService
    {
        private readonly IGorevDal _gorevDal;

        public GorevManager(IGorevDal gorevDal)
        {
            _gorevDal = gorevDal;
            
        }

        public Gorev GetirAciliyetId(int id)
        {
            return _gorevDal.GetirAciliyetId(id);
        }

        public List<Gorev> GetirAciliyetIleTamamlanmayan()
        {
            return _gorevDal.GetirAciliyetIleTamamlanmayan();
        }

        public List<Gorev> GetirHepsi()
        {
            return _gorevDal.GetirHepsi();
        }

        public Gorev GetirIdile(int id)
        {
            return _gorevDal.GetirIdile(id);
        }

        public List<Gorev> GetirileAppUserId(int appuserId)
        {
            return _gorevDal.GetirileAppUserId(appuserId);
        }

        public Gorev GetirRaporlarIdIle(int id)
        {
            return _gorevDal.GetirRaporlarIdIle(id);
        }

        public List<Gorev> GetirTumTablolar()
        {
            return _gorevDal.GetirTumTablolar();
        }

        public List<Gorev> GetirTumTablolar(Expression<Func<Gorev, bool>> filter)
        {
            return _gorevDal.GetirTumTablolar(filter);
        }

        public void Guncelle(Gorev tablo)
        {
            _gorevDal.Guncelle(tablo);
        }

        public void Kaydet(Gorev tablo)
        {
            _gorevDal.Kaydet(tablo);
        }

        public void Sil(Gorev tablo)
        {
            _gorevDal.Sil(tablo);
        }

    }
}
