using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.GorevDto;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
   public class GorevAddValidator : AbstractValidator<GorevAddDto>
    {
        public GorevAddValidator()
        {
            RuleFor(x => x.Ad).NotNull().WithMessage("Ad Boş Geçilemez");
            RuleFor(x => x.AciliyetId).ExclusiveBetween(0,int.MaxValue).WithMessage("Bir Durum Seçiniz");
        }
      
    }
}
