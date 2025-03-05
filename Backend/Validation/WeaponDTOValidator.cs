using FluentValidation;
using Backend.DTOs;

namespace Backend.Validation
{
    public class WeaponDTOValidator : AbstractValidator<WeaponDTO>
    {
        public WeaponDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Silah ismi boş olamaz.");

            RuleFor(x => x.DamageDice)
                .Matches(@"^(\d+)?d(\d+)([+-]\d+)?$")
                .WithMessage("Hasar zarı formatı geçersiz (Örnek: 1d6, 2d8+2)");

            RuleFor(x => x.Range)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Menzil negatif olamaz.");

            RuleFor(x => x.Weight)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Ağırlık negatif olamaz.");
        }
    }
}