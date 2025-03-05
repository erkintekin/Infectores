using FluentValidation;
using Backend.DTOs;

namespace Backend.Validation
{
    public class InventoryItemDTOValidator : AbstractValidator<InventoryItemDTO>
    {
        public InventoryItemDTOValidator()
        {
            RuleFor(x => x.ItemName)
                .NotEmpty().WithMessage("Item name is required")
                .MaximumLength(50).WithMessage("Item name cannot exceed 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.ItemType)
                .NotEmpty().WithMessage("Item type is required");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}