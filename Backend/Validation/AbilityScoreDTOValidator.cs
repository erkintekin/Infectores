using FluentValidation;
using Backend.DTOs;

namespace Backend.Validation
{
    public class AbilityScoreDTOValidator : AbstractValidator<AbilityScoreDTO>
    {
        public AbilityScoreDTOValidator()
        {
            RuleFor(x => x.Score)
                .InclusiveBetween(1, 30)
                .WithMessage("Yetenek puanı 1-30 arasında olmalıdır.");

            RuleFor(x => x.Modifier)
                .Must((abilityScore, modifier) =>
                    modifier == Math.Floor((abilityScore.Score - 10) / 2.0))
                .WithMessage("Yetenek düzenleyicisi doğru hesaplanmamış.");
        }
    }
}