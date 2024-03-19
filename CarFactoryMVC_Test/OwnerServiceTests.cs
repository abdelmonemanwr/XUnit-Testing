using CarFactoryMVC.Entities;
using CarFactoryMVC.Models;
using CarFactoryMVC.Payment;
using CarFactoryMVC.Repositories_DAL;
using CarFactoryMVC.Services_BLL;
using CarFactoryMVC_Test.Stups;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CarFactoryMVC_Test
{
    public class OwnerServiceTests : IDisposable
    {
        private readonly ITestOutputHelper outputHelper;

        Mock<ICarsRepository> carRepoMock;
        Mock<IOwnersRepository> ownerRepoMock;
        CashService cashService;
        OwnersService ownersService;
        public OwnerServiceTests(ITestOutputHelper outputHelper)
        {
            // test setup
            this.outputHelper = outputHelper;
            outputHelper.WriteLine("test setup");

            // any shared data between tests

            // create mock for dependencies
            carRepoMock = new Mock<ICarsRepository>();
            ownerRepoMock = new Mock<IOwnersRepository>();
            cashService = new CashService();

            // use fake dependences to create object
            ownersService = new(carRepoMock.Object, ownerRepoMock.Object, cashService);

            // connecto to test DB
        }

        public void Dispose()
        {
            // test cleanup
            outputHelper.WriteLine("test cleanup");
            // clean test DB state
        }

        [Fact]
        public void BuyCar_CarNotFound_NotExist()
        {
            // Arrang
            FactoryContext factoryContext = new FactoryContext();

            IOwnersRepository ownersRepository = new OwnerRepository(factoryContext);

            // create fake dependencies
            ICarsRepository carsRepository = new CarRepoStup();

            ICashService cashService = new CashService();

            OwnersService ownersService = new OwnersService(carsRepository,ownersRepository,cashService);

            BuyCarInput input = new BuyCarInput() { 
            CarId = 10,
            OwnerId = 2,
            Amount = 999999
            };

            // Act
            var result = ownersService.BuyCar(input);

            // Assert
            Assert.Contains("exist", result);
        }

        [Fact]
        public void BuyCar_CarSold_AlreadySold()
        {
            outputHelper.WriteLine("BuyCar_CarSold_AlreadySold");
            // Arrange

            // Create Mock of dependencies
            //Mock<ICarsRepository> carRepoMock = new Mock<ICarsRepository>();
            //Mock<IOwnersRepository> ownerRepoMock = new Mock<IOwnersRepository>();
            //CashService cashService = new CashService();

            // prepare mock Data
            Car car = new Car() {Id = 10 , Owner = new Owner() };
            //Owner owner = new Owner() {Id=5 };

            // setup the called methods
            carRepoMock.Setup(cr=>cr.GetCarById(It.IsAny<int>())).Returns(car);
           // ownerRepoMock.Setup(or => or.GetOwnerById(It.IsAny<int>())).Returns(owner);

            // use the fake object as dependency

            //OwnersService ownersService = new OwnersService(carRepoMock.Object,ownerRepoMock.Object,cashService);

            BuyCarInput input = new()
            {
                CarId = 8,
                OwnerId = 5,
                Amount = 9000
            };

            // Act
            var result = ownersService.BuyCar(input);
            // Assert
            Assert.Equal("Already sold", result);
        }

        [Fact]
        public void BuyCar_OwnerNotFound_NotExist()
        {
            outputHelper.WriteLine("BuyCar_OwnerNotFound_NotExist");
            // Arrange

            // prepare mock data
            Car car = new Car() { Id = 5 };
            Owner owner = null;

            // setup called method
            carRepoMock.Setup(cr=>cr.GetCarById(It.IsAny<int>())).Returns (car);
            ownerRepoMock.Setup(or => or.GetOwnerById(It.IsAny<int>())).Returns(owner);

            BuyCarInput buyCarInput = new()
            {
                CarId = 8,
                OwnerId = 10,
                Amount = 99999
            };

            // Act
            var result = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.Contains("exist", result);
        }

        
    }
}
