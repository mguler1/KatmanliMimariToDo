﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.UrunDto;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class UrunAddValidator: AbstractValidator<UrunAddDto>
    {
        public UrunAddValidator()
        {
            RuleFor(x => x.UrunAdi).NotNull().WithMessage("Urun Adı Boş Geçilemez");
        }
           

    
}
}
