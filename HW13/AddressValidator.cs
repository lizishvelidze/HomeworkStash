using FluentValidation;
using HW13.Models;

namespace HW13
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Country)
                .NotEmpty().WithMessage("Country is required.");

            RuleFor(address => address.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(address => address.HomeNumber)
                .NotEmpty().WithMessage("Home number is required.");   
        }
    }
}
