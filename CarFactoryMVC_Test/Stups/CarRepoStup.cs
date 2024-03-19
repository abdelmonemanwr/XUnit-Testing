using CarFactoryMVC.Entities;
using CarFactoryMVC.Repositories_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryMVC_Test.Stups
{
    internal class CarRepoStup : ICarsRepository
    {
        public bool AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public bool AssignToOwner(int carId, int OwnerId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int id)
        {
            return null;
        }

        public bool Remove(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
