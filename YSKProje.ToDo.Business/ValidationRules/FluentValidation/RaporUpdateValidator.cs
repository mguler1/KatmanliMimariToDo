using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.RaporDto;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class RaporUpdateValidator : AbstractValidator<RaporUpdateDto>
    {
        public RaporUpdateValidator()
        {

            RuleFor(x => x.Tanim).NotNull().WithMessage("Tanım Boş Geçilemez");
            RuleFor(x => x.Detay).NotNull().WithMessage("Detay Boş Geçilemez");
        }
    }
}
