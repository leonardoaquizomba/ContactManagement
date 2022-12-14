using ContactManagement.Interfaces;
using ContactManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.Pages.Contacts
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public IList<Contact> Contacts { get; set; } = default!;
        private readonly IContactRepository _contactRepository;
        public IndexModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;

            if (_contactRepository.GetAll().ToList().Count > 0)
            {
                Contacts = _contactRepository.GetAll().ToList();
            }
            else
            {
                Contacts = new List<Contact>();
            }
        }
    }
}
