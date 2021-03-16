using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Interfaces
{
    public interface IGorevService : IGenericService<Gorev>
    {
        List<Gorev> GetirAciliyetIleTamamlanmayan();
        List<Gorev> GetirTumTablolar();
        List<Gorev> GetirTumTablolar(Expression<Func<Gorev, bool>> filter);
        Gorev GetirAciliyetId(int id);
        List<Gorev> GetirileAppUserId(int appuserId);
         Gorev GetirRaporlarIdIle(int id);
    }
}
