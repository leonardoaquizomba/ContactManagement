using ContactManagement.Interfaces;
using ContactManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly IContactRepository _contactRepository;
        public Contact Contact { get; set; }
        public DetailsModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void OnGet(long id)
        {
            Contact = _contactRepository.GetById(id);
        }

    }
}
