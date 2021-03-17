using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.GorevDto;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
  public  class GorevUpdateValidator : AbstractValidator<GorevUpdateDto>
    {
        public GorevUpdateValidator()
        {
            RuleFor(x => x.Ad).NotNull().WithMessage("Ad Boş Geçilemez");
            RuleFor(x => x.AciliyetId).ExclusiveBetween(1, int.MaxValue).WithMessage("Bir Durum Seçiniz");
        }
    }
}
