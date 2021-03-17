using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.AciliyetDto;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class AciliyetAddValidator:AbstractValidator<AciliyetAddDto>
    {
        public AciliyetAddValidator()
        {
            RuleFor(x => x.Tanim).NotNull().WithMessage("Tanım Alanı Boş Geçilemez");

        }
    }
}
