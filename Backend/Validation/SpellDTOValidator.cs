using FluentValidation;
using Backend.DTOs;

namespace Backend.Validation
{
    public class SpellDTOValidator : AbstractValidator<SpellDTO>
    {
        public SpellDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Büyü ismi boş olamaz.")
                .Length(2, 50).WithMessage("Büyü ismi 2-50 karakter arasında olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Büyü açıklaması boş olamaz.");

            RuleFor(x => x.Range)
                .GreaterThanOrEqualTo(0).WithMessage("Menzil negatif olamaz.");

            RuleFor(x => x.Components)
                .NotEmpty().WithMessage("En az bir bileşen gereklidir.");
        }
    }
}