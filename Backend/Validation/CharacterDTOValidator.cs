using FluentValidation;
using Backend.DTOs;

namespace Backend.Validation
{
    public class CharacterDTOValidator : AbstractValidator<CharacterDTO>
    {
        public CharacterDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Karakter ismi boş olamaz.")
                .Length(2, 50).WithMessage("Karakter ismi 2-50 karakter arasında olmalıdır.");

            RuleFor(x => x.Level)
                .GreaterThanOrEqualTo(1).WithMessage("Seviye en az 1 olmalıdır.")
                .LessThanOrEqualTo(20).WithMessage("Seviye en fazla 20 olabilir.");

            RuleFor(x => x.ArmorClass)
                .GreaterThanOrEqualTo(10).WithMessage("Zırh sınıfı en az 10 olmalıdır.");

            RuleFor(x => x.XP)
                .GreaterThanOrEqualTo(0).WithMessage("Deneyim puanı negatif olamaz.");
        }
    }
}