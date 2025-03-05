using FluentValidation;
using Backend.DTOs;

namespace Backend.Validation
{
    public class ArmorDTOValidator : AbstractValidator<ArmorDTO>
    {
        public ArmorDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Armor name is required")
                .MaximumLength(50).WithMessage("Armor name cannot exceed 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.ArmorType)
                .NotEmpty().WithMessage("Armor type is required");

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