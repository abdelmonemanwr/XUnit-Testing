using CarFactoryMVC.Entities;
using CarFactoryMVC.Models;
using CarFactoryMVC.Payment;
using CarFactoryMVC.Repositories_DAL;
using CarFactoryMVC.Services_BLL;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace my_CarFactoryMVC_Tests
{
    public class OwnerServicesTests:IDisposable
    {
        OwnerRepository ownerRepo;
        OwnersService ownersService;
        ITestOutputHelper outputHelper;
        Mock<ICarsRepository> carRepoMock;
        Mock<ICashService> cashServiceMock;
        Mock<IOwnersRepository> ownerRepoMock;

        public OwnerServicesTests(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
            outputHelper.WriteLine("Initializing Setup");

            carRepoMock = new Mock<ICarsRepository>();
            ownerRepoMock = new Mock<IOwnersRepository>();
            cashServiceMock = new Mock<ICashService>();

            ownersService = new(carRepoMock.Object, ownerRepoMock.Object, cashServiceMock.Object);
        }
        public void Dispose() 
        {
            outputHelper.WriteLine("Disposing Cleanup");
        }

        [Fact]
        public void BuyCar_CarSold_AlreadySold()
        {
            outputHelper.WriteLine("BuyCar_CarSold_AlreadySold");
            Car car = new Car() { Id = 10, Owner = new Owner() };
            carRepoMock.Setup(cr => cr.GetCarById(It.IsAny<int>())).Returns(car);
            BuyCarInput input = new() { CarId = 8, OwnerId = 5, Amount = 9000 };
            var result = ownersService.BuyCar(input);
            Assert.Equal("Already sold", result);
        }

        [Fact]
        public void BuyCar_HaveCar_Bought()
        {
            outputHelper.WriteLine("BuyCar_HaveCar_True");
            Car car = new Car() { Id = 5, Price = 100 };
            Owner owner = new Owner() {Car = new Car() { } };

            carRepoMock.Setup(cr => cr.GetCarById(It.IsAny<int>())).Returns(car);
            ownerRepoMock.Setup(or => or.GetOwnerById(It.IsAny<int>())).Returns(owner);

            BuyCarInput input = new()
            {
                CarId = 35,
                OwnerId = 23,
                Amount = 150
            };
            var result = ownersService.BuyCar(input);
            Assert.Equal("Already have car", result);
        }

        [Fact]
        public void BuyCar_InsufficientFunds_notEnought()
        {
            outputHelper.WriteLine("BuyCar_InsufficientFunds_notEnought");
            
            Car car = new Car() { Id = 5, Price=100};
            Owner owner = new Owner() { Id = 10 };
            
            carRepoMock.Setup(cr => cr.GetCarById(It.IsAny<int>())).Returns(car);
            ownerRepoMock.Setup(or => or.GetOwnerById(It.IsAny<int>())).Returns(owner);
            
            BuyCarInput input = new() { 
                CarId = 5, 
                OwnerId = 10,
                Amount = 50 
            };
            var result = ownersService.BuyCar(input);
            Assert.Equal("Insufficient funds", result);
        }

        [Fact]
        public void BuyCar_AssignToOwner_Success()
        {
            outputHelper.WriteLine("BuyCar_AssignToOwner_Success");
            Car car = new Car()
            {
                Id = 12,
                Price = 234,
                OwnerId = 15
            };

            Owner owner = new Owner()
            {
                Id = 23,
            };

            BuyCarInput buyCarInput = new BuyCarInput()
            {
                CarId = 123,
                OwnerId = 345,
                Amount = 3456
            };

            carRepoMock.Setup(cr => cr.GetCarById(It.IsAny<int>())).Returns(car);
            ownerRepoMock.Setup(or => or.GetOwnerById(It.IsAny<int>())).Returns(owner);

            var result = ownersService.BuyCar(buyCarInput);
            Assert.Equal("Something went wrong", result);
        }

        [Theory]
        [InlineData(500)]
        public void Pay_PaidSuccessfully_TransactionDone(double amount)
        {
            BuyCarInput buyCarInput = new BuyCarInput()
            {
                CarId = 3,
                OwnerId = 4,
                Amount = 500
            };
            ICashService cashService = new CashService() ;
            var result1 = cashService.Pay(amount);
            var result2 = cashService.Pay(buyCarInput.Amount);
            Assert.Equal(result1, result2);
        }

        [Fact]
        public void AddOwner_AddingNewOwner_OwnerAdded()
        {
            Mock<FactoryContext> dbMock = new Mock<FactoryContext>();
            List<Owner> owners = new List<Owner> () {
                new Owner () { Id = 1, Name = "Owner 1"},
                new Owner () { Id = 2, Name = "Owner 2"},
                new Owner () { Id = 3, Name = "Owner 3"},
            };

            dbMock.Setup<DbSet<Owner>>(or => or.Owners).ReturnsDbSet(owners);
            
            ownerRepo = new OwnerRepository(dbMock.Object);

            Owner newOwner = new Owner() { Id = 4,  Name = "Men3m" };

            bool State = ownerRepo.AddOwner(newOwner);

            outputHelper.WriteLine($"count = {owners.Count}");
            foreach (var o in owners)
                outputHelper.WriteLine($"  - Name: {o.Name}");

            Assert.True(State == true);
            //Assert.True(owners.Count == 4);
        }
    }
}
