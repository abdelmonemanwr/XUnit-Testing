using CarFactoryMVC.Entities;
using CarFactoryMVC.Repositories_DAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryMVC_Test
{
    public class CarRepositoryTests
    {
        [Fact]
        public void GetAllCars_returnCarList()
        {
            // Arrange
            // Create mock of dependencies
            Mock<FactoryContext> factoryContext = new Mock<FactoryContext>();

            // prepare mock data
            List<Car> cars = new List<Car>()
            {
                new Car(){Id = 10},
                new Car(){Id = 20},
                new Car(){Id = 30},
            };

            // setup called Dbset
            factoryContext.Setup<DbSet<Car>>(fc=>fc.Cars).ReturnsDbSet(cars);

            // use the fake object as dependency
            CarRepository carRepository = new CarRepository(factoryContext.Object);

            // Act
            List<Car> result = carRepository.GetAllCars();

            // Assert
            Assert.Equal(3, result.Count);
        }
    }
}
