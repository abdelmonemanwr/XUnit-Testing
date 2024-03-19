
using CarFactoryMVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarFactoryMVC.Repositories_DAL
{
    public class CarRepository : ICarsRepository
    {
        private readonly FactoryContext context;

        public CarRepository(FactoryContext context)
        {
            this.context = context;
        }
        public bool AddCar(Car car)
        {
            try
            {
                context.Cars.Add(car);
                context.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }

        public List<Car> GetAllCars()
        {
            return context.Cars.Include(c => c.Owner).ToList();
        }

        public Car GetCarById(int id)
        {
            //throw new NotImplementedException();
            return context.Cars.Include(c=>c.Owner).SingleOrDefault(c => c.Id == id);
        }

        public bool Remove(int carId)
        {
            try
            {
                context.Cars.Remove(GetCarById(carId));
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AssignToOwner(int carId, int OwnerId)
        {
            try
            {
                Car car = GetCarById(carId);
                if (car == null) return false;

                car.OwnerId = OwnerId;
                context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

    }
}
