using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_CarFactoryLibrary_Test
{
    public class Car_Tests
    {
        [Fact]
        [Trait("Author", "Men3m")]
        public void myTimeToCoverDistance_Velocity15_Ok()
        {
            Car car = new BMW() { velocity = 15 };

            double distance = 100;
            double expectedTime = distance / car.velocity;

            Assert.Equal(expectedTime, car.myTimeToCoverDistance(distance));
        }

        [Fact]
        [Trait("Author", "Men3m")]
        public void myTimeToCoverDistance_Velocity0_Exception()
        {
            Car car = new BMW() { velocity = 0 };
            Assert.Throws<DivideByZeroException>(() =>
            {
                car.myTimeToCoverDistance(100.0);
            });
        }

        [Fact]
        [Trait("Author", "Men3m")]
        public void IncreaseVelocity_Velocity25_increasedBy25()
        {
            Car car = new BMW() { velocity = 15 };
            car.IncreaseVelocity(25);
            Assert.True(car.velocity == 40, "increase velocity isn't working properly");
        }

        [Fact]
        [Trait("Author", "Men3m")]
        public void GetDirection_Velocity25_increasedBy25()
        {
            Car car = new BMW() { velocity = 15 };
            var result = car.GetDirection();
            // regex
            Assert.Matches("Forward|Backward|Stopped", result);
        }
    }
}
