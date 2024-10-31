using System.ComponentModel.DataAnnotations;
using System;

namespace Homework12.Models
{
    public class Appointment
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Doctor { get; set; }

        public string Time { get; set; }
    }
    public class TimeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string timeString && DateTime.TryParse(timeString, out DateTime time))
            {
                if (time.Hour >= 10 && time.Hour < 19)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Appointment time must be between 10:00 and 19:00.");
        }
    }
}

