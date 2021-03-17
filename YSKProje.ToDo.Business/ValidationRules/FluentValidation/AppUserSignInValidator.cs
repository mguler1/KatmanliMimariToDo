using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.AppUserDto;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSigInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre Boş Geçilemez");
        }
    }
}
