using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test
{
    public class CarStoreTests
    {
        [Fact(Skip = "Working on handling error")]
        [Trait("Author","Ahmed")]
        [Trait("Priority", "1")]

        public void AddCars_ListOF3Elements_NotEmpty()
        {
            // Arrange
            CarStore carStore = new CarStore();

            Car car = new Toyota { velocity = 10, drivingMode = DrivingMode.Forward };
            List<Car> cars = new List<Car>()
            {
                car,
                new BMW{velocity = 15, drivingMode=DrivingMode.Forward},
                new Toyota{velocity = 30, drivingMode=DrivingMode.Forward},
            };

            // Act
            carStore.AddCars(cars);

            // Collection Asserts
            //Assert.Empty(cars);
            Assert.NotEmpty(cars);

            Car car1 = new BMW { velocity = 10, drivingMode = DrivingMode.Forward };
            // Value Equality
            Assert.Contains<Car>(car, carStore.cars);
            Assert.Contains<Car>(car1, carStore.cars);

            //Assert.Contains<Car>(carStore.cars, car => car.drivingMode == DrivingMode.Stopped);

        }
    }
}
