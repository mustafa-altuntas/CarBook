using CarBook.Aplication.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Validators.ReviewValidators
{
    public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz")
    .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.");
            RuleFor(x => x.RaytingValue).NotNull().WithMessage("Lütfen puan değerini boş geçmeyiniz.");
            RuleFor(x => x.Comment).Empty().WithMessage("Lütfen yorum değerini boş geçmeyiniz.");
        }
    }
}
