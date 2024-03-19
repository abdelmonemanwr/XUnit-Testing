
using CarFactoryMVC.Entities;
using CarFactoryMVC.Models;

namespace CarFactoryMVC.Services_BLL
{
    public interface IOwnersService
    {
        bool AddOwner(Owner owner);
        string BuyCar(BuyCarInput input);
        Owner GetById(int id);
        List<Owner> GetOwners();
    }
}