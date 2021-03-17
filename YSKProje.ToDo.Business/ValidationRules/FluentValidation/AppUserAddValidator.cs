using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YskProje.Todo.DTO.DTOs.AppUserDto;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
   public class AppUserAddValidator: AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.Name).NotNull().WithMessage("Ad Boş Geçilemez");
            RuleFor(x => x.Surname).NotNull().WithMessage("SoyAd Boş Geçilemez");
            RuleFor(x => x.Password).NotNull().WithMessage("Parola Boş Geçilemez");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Parola Onay Boş Geçilemez");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalar Eşleşmemektedir");
            RuleFor(x => x.Email).EmailAddress().NotNull().WithMessage("Geçersiz E-Posta Adresi");
        }
    }
}
