using ContactManagement.Data.Context;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Validation
{
    public class PhoneCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            if (!context.Contacts.Any(a => a.Phone.Trim() == value.ToString().Trim()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Phone exists");
        }
    }
}
