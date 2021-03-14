using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("getirGorevAppUserId")]
    public class GorevAppUserIdTagHelper:TagHelper
    {
        private readonly IGorevService _gorevservice;
        public GorevAppUserIdTagHelper(IGorevService gorevService)
        {
            _gorevservice = gorevService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
         List<Gorev> gorevler=  _gorevservice.GetirileAppUserId(AppUserId);
          int tamamlananlar=  gorevler.Where(x => x.Durum == true).Count();
          int ustundeCalistigiGorevSayisi=  gorevler.Where(x => x.Durum == false).Count();
            string htmlString = $"<strong> Tamamladığı Görev Sayısı :</strong>{tamamlananlar} <br> <strong>Üstünde Çalıştığı Görev Sayısı :</strong>{ustundeCalistigiGorevSayisi}";
            output.Content.SetHtmlContent(htmlString);
        }
    }
}
