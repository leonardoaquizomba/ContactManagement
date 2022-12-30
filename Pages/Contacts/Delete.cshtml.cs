using ContactManagement.Interfaces;
using ContactManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly IContactRepository _contactRepository;

        [BindProperty]
        public Contact Contact { get; set; }

        public DeleteModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void OnGet(long id)
        {
            Contact = _contactRepository.GetById(id);
        }

        public void OnPost()
        {
            _contactRepository.Remove(Contact.Id);
            RedirectToPage("./Index");
        }
    }
}
