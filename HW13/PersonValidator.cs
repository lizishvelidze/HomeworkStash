using FluentValidation;
using HW13.Models;
using System;

namespace HW13
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        { 
            RuleFor(person => person.CreateDate)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Create date must not be older than today.");

            RuleFor(person => person.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .Length(0, 50).WithMessage("Length should be from 0 to 50 characters long.");

            RuleFor(person => person.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .Length(0, 50).WithMessage("Length should be from 0 to 50 characters long.");

            RuleFor(person => person.JobPosition)
                .NotEmpty().WithMessage("Job position is required")
                .Length(0, 50).WithMessage("Length should be from 0 to 50 characters long.");

            RuleFor(person => person.Salary)
                .NotEmpty().WithMessage("Salary is required")
                .GreaterThan(0).WithMessage("Salary must be a positive number")
                .LessThan(100001).WithMessage("Salary must be no greater than 10.000");

            RuleFor(person => person.WorkExperince)
                .NotEmpty().WithMessage("Work experience name is required");

            RuleFor(person => person.PersonAddress)
               .SetValidator(new AddressValidator());


        }
    }
}
