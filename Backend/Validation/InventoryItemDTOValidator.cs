using FluentValidation;
using Backend.DTOs;

namespace Backend.Validation
{
    public class InventoryItemDTOValidator : AbstractValidator<InventoryItemDTO>
    {
        public InventoryItemDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Eşya ismi boş olamaz.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.");

            RuleFor(x => x.GP)
                .GreaterThanOrEqualTo(0).WithMessage("Altın değeri negatif olamaz.");
        }
    }
}