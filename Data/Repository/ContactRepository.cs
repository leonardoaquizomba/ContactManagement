using ContactManagement.Data.Context;
using ContactManagement.Interfaces;
using ContactManagement.Model;

namespace ContactManagement.Data.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
