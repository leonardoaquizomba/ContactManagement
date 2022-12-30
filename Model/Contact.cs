using ContactManagement.Validation;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Model
{
    public class Contact : EntityAudit
    {
        //protected Contact() { }

        [DataType(DataType.Text)]
        [Required]
        [MinLength(5)]
        [MaxLength(191)]
        [Display(Name = "Your name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Your phone")]
        [MinLength(5)]
        [PhoneCheck]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Your e-mail")]
        [EmailCheck]
        [MaxLength(191)]
        public string Email { get; set; }
    }
}
