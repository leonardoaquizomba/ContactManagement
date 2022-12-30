using ContactManagement.Interfaces;
using ContactManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly IContactRepository _contactRepository;

        [BindProperty]
        public Contact Contact { get; set; }

        public EditModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void OnGet(long id)
        {
            Contact = _contactRepository.GetById(id);
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                Page();
            }

            _contactRepository.Update(Contact);
            _contactRepository.SaveChanges();
            RedirectToPage("./Index");
        }
    }
}
