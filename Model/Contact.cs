using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Model
{
    public class Contact : EntityAudit
    {
        private string _name;
        private int _phone;
        private string _email;

        public Contact(string name, int phone, string email)
        {
            _name = name;
            _phone = phone;
            _email = email;
        }

        protected Contact() { }

        [DataType(DataType.Text, ErrorMessage = "")]
        [Required]
        [MinLength(5)]
        public string Name { get => _name; set => _name = value; }

        [Required]
        public int Phone { get => _phone; set => _phone = value; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        [Display(Name = "E-mail")]
        public string Email { get => _email; set => _email = value; }
    }
}
