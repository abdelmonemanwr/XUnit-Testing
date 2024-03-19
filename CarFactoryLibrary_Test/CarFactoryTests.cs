using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test
{
    public class CarFactoryTests
    {
        [Fact]
        [Trait("Author", "Ahmed")]
        [Trait("Priority", "2")]


        public void NewCar_AskForAudi_null()
        {
            // Arrange

            // Act
            var result = CarFactory.NewCar(CarTypes.Audi);

            // Reference Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait("Author", "Omar")]
        [Trait("Priority", "1")]

        public void NewCar_AskForToyota_Toyota()
        {
            // Arrange

            // Act
            var result = CarFactory.NewCar(CarTypes.Toyota);

            // Reference Assert
            Assert.NotNull(result);

            // Type Asserts
            Assert.IsType<Toyota>(result);
            //Assert.IsType<BMW>(result);

            Assert.IsAssignableFrom<Car>(result);
        }

        [Fact]
        [Trait("Author", "Ahmed")]

        public void NewCar_AskForHonda_Exception()
        {
            // Arrange



            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}
