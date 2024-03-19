

using CarFactoryMVC.Entities;

namespace CarFactoryMVC.Repositories_DAL
{
    public interface ICarsRepository
    {
        bool AddCar(Car car);
        List<Car> GetAllCars();
        Car GetCarById(int id);
        bool Remove(int carId);
        bool AssignToOwner(int carId, int OwnerId);
    }
}