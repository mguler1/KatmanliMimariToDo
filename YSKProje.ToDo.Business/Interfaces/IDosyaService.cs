using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.Business.Interfaces
{
    public interface IDosyaService
    {
        string AktarPdf<T>(List<T> list) where T:class,new();//dosya yolunu döndürecek
        byte[] AktarExcel<T>(List<T> list) where T : class, new();//excel verisini byte şeklinde döndürecek

    }
}
