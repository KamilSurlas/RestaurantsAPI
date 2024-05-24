using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.UpdateDish
{
    public class UpdateDishCommandValidator : AbstractValidator<UpdateDishCommand>
    {
        public UpdateDishCommandValidator()
        {
            RuleFor(command => command.Price)
              .GreaterThanOrEqualTo(0)
              .WithMessage("Price must be at least 0.0");

            RuleFor(command => command.KiloCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Kilo calories must be at least 0");
        }
    }
}
