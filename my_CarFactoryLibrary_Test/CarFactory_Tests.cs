using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_CarFactoryLibrary_Test
{
    public class CarFactory_Tests
    {

        [Fact]
        [Trait("Author", "Men3m")]
        public void NewCar_InjectToyota_Toyota()
        {
            var toyota = CarFactory.NewCar(CarTypes.Toyota);
            Assert.IsAssignableFrom<Car>(toyota);
        }

        [Fact]
        [Trait("Author", "Men3m")]
        public void GetMyCar_CarReference_True()
        {
            Car bmw = new BMW();
            Car toyota = new Toyota();
            Assert.NotSame(bmw, toyota);

            Car car = bmw.GetMyCar();
            Assert.Same(car, bmw);

            Car audi = CarFactory.NewCar(CarTypes.Audi);
            Assert.Null(audi);
        }
    }
}