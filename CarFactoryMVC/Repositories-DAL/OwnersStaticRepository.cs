

using CarFactoryMVC.Entities;

namespace CarFactoryMVC.Repositories_DAL
{
    public class OwnersStaticRepository : IOwnersRepository
    {

        private readonly IInMemoryContext _context;

        public OwnersStaticRepository(IInMemoryContext inMemoryContext)
        {
            _context = inMemoryContext;
        }

        public List<Owner> GetAllOwners()
        {
            return _context.Owners;
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == id);
        }

        public bool AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            return true;
        }

    }
}