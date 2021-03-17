using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGorevRepository : EfGenericRepository<Gorev>, IGorevDal
    {
        public Gorev GetirAciliyetId(int id)
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(x => x.Aciliyet).FirstOrDefault(x => !x.Durum && x.Id == id);
        }

        public List<Gorev> GetirAciliyetIleTamamlanmayan()
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(x => x.Aciliyet).Where(x => x.Durum == false).OrderByDescending(x => x.OlusturulmaTarih).ToList();
        }

        public List<Gorev> GetirileAppUserId(int appuserId)
        {
            using var context = new TodoContext();
            return context.Gorevler.Where(x => x.AppUserId == appuserId).ToList();
        }

        public Gorev GetirRaporlarIdIle(int id)
        {
            using var context = new TodoContext();
          return  context.Gorevler.Include(x => x.Raporlar).Include(x=>x.AppUser).Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Gorev> GetirTumTablolar()
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(x => x.Aciliyet).Include(x => x.Raporlar).Include(x => x.AppUser).Where(x => x.Durum == false).OrderByDescending(x => x.OlusturulmaTarih).ToList();
        }

        public List<Gorev> GetirTumTablolar(Expression<Func<Gorev, bool>> filter)
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(x => x.Aciliyet).Include(x => x.Raporlar).Include(x => x.AppUser).Where(filter).OrderByDescending(x => x.OlusturulmaTarih).ToList();
        }

        public List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId,int aktifSayfa=1)
        {
            using var context = new TodoContext();
            var returnValue = context.Gorevler.Include(x => x.Aciliyet).Include(x => x.Raporlar).Include(x => x.AppUser).Where(x => x.AppUserId == userId && x.Durum).OrderByDescending(x => x.OlusturulmaTarih);
            toplamSayfa =(int)Math.Ceiling((double)returnValue.Count() / 3);
            return returnValue.Skip((aktifSayfa - 1) * 4).Take(4).ToList();
        }
    }
}
