using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test
{
    public class CarTests
    {
        [Fact]
        public void IsStopped_CarVelocity20_False()
        {
            // Arrange
            Car car = new Toyota() { velocity = 20, drivingMode = DrivingMode.Forward };

            // Act
            var result = car.IsStopped();

            // Boolean Assert
            Assert.False(result);
        }
        [Fact]
        public void IsStopped_CarVelocity0_True()
        {
            // Arrange
            Car car = new Toyota();

            // Act
            var result = car.IsStopped();

            // Boolean Assert
            Assert.True(result);
        }
        [Fact]
        public void GetDirection_CarModeForward_Forward()
        {
            // Arrange
            Car car = new Toyota() { velocity = 15, drivingMode= DrivingMode.Forward };

            // Act
            var result = car.GetDirection();

            // Equality Assert
            //Assert.Equal("Forward", result);


            // String Assert
            Assert.StartsWith("F", result);
            Assert.EndsWith("d", result);
            Assert.Contains("wa", result);
            Assert.DoesNotContain("x", result);

            // Assert.Matches("regex", result);
            // Assert.DoesNotMatch("regex", result);
        }

        [Fact]
        public void IncreaseVelocity_CarVelocity10IncreseBy5_Velocity15()
        {
            // Arrange
            Car car = new Toyota() { velocity = 10 };

            // Act
            car.IncreaseVelocity(5);

            // Assert
            Assert.Equal(15, car.velocity);
        }

        [Fact]
        public void Accelerate_CarVelocity20_VelocityIncrease()
        {
            // Arrage
            //Car car = new Toyota { velocity = 20 };
            Car car = new BMW { velocity = 20 };

            // Act
            car.Accelerate();   // range 5 to 15

            // Numeric Assert
            Assert.InRange(car.velocity, 25, 35);
           // Assert.NotInRange()
        }

        [Fact]
        public void GetMyCar_car_same()
        {
            // Arrange
            Car car = new Toyota();
            Car car1 = new Toyota();

            // Act
            Car car2 = car.GetMyCar();

            // Assert
            // Reference Equality
            Assert.Same(car, car2);
            Assert.NotSame(car, car1);

            // Value Equality
            Assert.Equal<Car>(car, car1);
        }
    }
}
