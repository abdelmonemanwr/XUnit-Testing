
using CarFactoryMVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarFactoryMVC.Repositories_DAL
{
    public class OwnerRepository : IOwnersRepository
    {
        private readonly FactoryContext context;

        public OwnerRepository(FactoryContext context)
        {
            this.context = context;
        }
        public bool AddOwner(Owner owner)
        {
            try
            {
                context.Owners.Add(owner);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Owner> GetAllOwners()
        {
            return context.Owners.Include(o => o.Car).ToList();
        }

        public Owner GetOwnerById(int id)
        {
            return context.Owners.Include(o=>o.Car).SingleOrDefault(o => o.Id == id);
        }
    }
}
