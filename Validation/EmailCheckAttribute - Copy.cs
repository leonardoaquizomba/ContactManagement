﻿using ContactManagement.Data.Context;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Validation
{
    public class EmailCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            if (!context.Contacts.Any(a => a.Email.ToLower() == value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Email exists");
        }
    }
}
