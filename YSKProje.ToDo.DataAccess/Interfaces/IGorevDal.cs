using System.Collections.Generic;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Interfaces
{
    public interface IGorevDal : IGenericDal<Gorev>
    {
        List<Gorev> GetirAciliyetIleTamamlanmayan();
        List<Gorev> GetirTumTablolar();
        Gorev GetirAciliyetId(int id);
        List<Gorev> GetirileAppUserId(int appuserId);
         Gorev GetirRaporlarIdIle(int id);
    }
}
