using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.RaporDto;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
   public class RaporAddValidator : AbstractValidator<RaporAddDto>
    {
        public RaporAddValidator()
        {
            RuleFor(x => x.Tanim).NotNull().WithMessage("Tanım Boş Geçilemez");
            RuleFor(x => x.Detay).NotNull().WithMessage("Detay Boş Geçilemez");
        }
    }
}
