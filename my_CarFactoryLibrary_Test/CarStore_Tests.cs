using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_CarFactoryLibrary_Test
{
    public class CarStore_Tests
    {

        [Fact]
        [Trait("Author", "Men3m")]
        public void AddCars_LengthAfterAdding3Cars_Number()
        {
            List<Car> newCars = new List<Car>()
            {
                new Toyota {velocity = 0, drivingMode=DrivingMode.Stopped},
                new Toyota {velocity = 10, drivingMode=DrivingMode.Backward},
                new BMW {velocity = 20, drivingMode=DrivingMode.Forward},
            };

            CarStore carStore = new CarStore();
            
            carStore.AddCar(new BMW { velocity = 0, drivingMode = DrivingMode.Stopped });
            
            int oldCarsNumber = carStore.cars.Count();

            carStore.AddCars(newCars);

            Assert.Equal(carStore.cars.Count(), oldCarsNumber + 3);
        }
    }
}
