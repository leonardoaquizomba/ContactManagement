using ContactManagement.Interfaces;
using ContactManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.Pages.Contacts
{
    [Authorize]
    public class AddModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }
        private readonly IContactRepository _contactRepository;
        public AddModel(IContactRepository contactRepository)
        {
            Contact = new Contact();
            _contactRepository = contactRepository;
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                Page();
            }

            _contactRepository.Add(Contact);
            _contactRepository.SaveChanges();
            RedirectToPage("./Index");
        }
    }
}
