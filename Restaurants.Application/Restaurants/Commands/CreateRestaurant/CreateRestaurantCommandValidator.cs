using FluentValidation;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    public CreateRestaurantCommandValidator(IRestaurantsRepository restaurantsRepository)
    {
        _restaurantsRepository = restaurantsRepository;

        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX).");

        RuleFor(x => x.ContactEmail)
            .EmailAddress().Custom((value, context) =>
        {
            var existingEmail = _restaurantsRepository.GetAllAsync().Result.Any(r=>r.ContactEmail==value);
            if (existingEmail)
            {
                context.AddFailure("Email", $"Email {value} is already in use");
            }
        });

        RuleFor(x => x.ContactNumber).Length(9,13).Custom((value, context) =>
        {
            var existingEmail = _restaurantsRepository.GetAllAsync().Result.Any(r => r.ContactNumber == value);
            if (existingEmail)
            {
                context.AddFailure("ContactNumber", $"Contact number {value} is already in use");
            }
        });
    }
}
