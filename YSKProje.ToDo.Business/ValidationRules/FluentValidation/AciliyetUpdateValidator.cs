using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.AciliyetDto;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
   public class AciliyetUpdateValidator:AbstractValidator<AciliyetUpdateDto>
    {
        public AciliyetUpdateValidator()
        {
            RuleFor(x => x.Tanim).NotNull().WithMessage("Tanım Alanı Boş Geçilemez");
        }
    }
}
