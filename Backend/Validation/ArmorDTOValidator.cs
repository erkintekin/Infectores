using FluentValidation;
using Backend.DTOs;

namespace Backend.Validation
{
    public class ArmorDTOValidator : AbstractValidator<ArmorDTO>
    {
        public ArmorDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Zırh ismi boş olamaz.");

            RuleFor(x => x.BaseAC)
                .GreaterThanOrEqualTo(10)
                .WithMessage("Temel Zırh Sınıfı en az 10 olmalıdır.");

            RuleFor(x => x.DexterityModifier)
                .InclusiveBetween(0, 10)
                .WithMessage("Çeviklik düzenleyicisi 0-10 arasında olmalıdır.");

            RuleFor(x => x.StealthDisadvantage)
                .NotNull()
                .WithMessage("Gizlilik dezavantajı belirtilmelidir.");
        }
    }
}