using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        CarManager.Car car;
        [SetUp]
        public void Setup() { }

        [Test]
        public void Ctor_Valid()
        {
            CarManager.Car car = new CarManager.Car("Mazda", "RX-8", 11, 30);
            Assert.IsNotNull(car);
            Assert.That(car.Make == "Mazda");
            Assert.That(car.Model == "RX-8");
            Assert.That(car.FuelConsumption == 11);
            Assert.That(car.FuelCapacity == 30);
        }

        [Test]
        public void Ctor_Invalid_Make()
        { Assert.Throws<ArgumentException>(() => { CarManager.Car c = new CarManager.Car(null, "RX-8", 11, 30); }); }

        [Test]
        public void Ctor_Invalid_Model()
        { Assert.Throws<ArgumentException>(() => { CarManager.Car c = new CarManager.Car("Mazda", null, 11, 30); }); }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_Invalid_FuelConsumption(double fc)
        { Assert.Throws<ArgumentException>(() => { CarManager.Car c = new CarManager.Car("Mazda", "RX-8", fc, 30); }); }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_Invalid_FuelCapacity(double fc)
        { Assert.Throws<ArgumentException>(() => { CarManager.Car c = new CarManager.Car("Mazda", "RX-8", 11, fc); }); }

        [Test]
        public void Ctor_FuelAmound()
        {
            CarManager.Car c = new CarManager.Car("Mazda", "RX-8", 11, 30);
            Assert.That(c.FuelAmount == 0);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Refuel_With_0_Or_Negative(double fuel)
        {
            CarManager.Car car = new CarManager.Car("Mazda", "RX-8", 11, 30);
            Assert.Throws<ArgumentException>(() => { car.Refuel(fuel); });
        }

        [Test]
        public void Refuel_Over_Capacity()
        {
            CarManager.Car car = new CarManager.Car("Mazda", "RX-8", 11, 30);
            car.Refuel(60);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void Refuel_Valid()
        {
            CarManager.Car car = new CarManager.Car("Mazda", "RX-8", 11, 30);
            car.Refuel(20);
            Assert.AreEqual(20, car.FuelAmount);
        }

        [Test]
        public void Drive_Valid()
        {
            CarManager.Car car = new CarManager.Car("Mazda", "RX-8", 11, 30);
            car.Refuel(30);
            car.Drive(10);
            Assert.That(car.FuelAmount < car.FuelCapacity);
        }

        [Test]
        public void Drive_Not_Enough_Fuel()
        {
            CarManager.Car car = new CarManager.Car("Mazda", "RX-8", 11, 30);
            Assert.Throws<InvalidOperationException>(() => { car.Drive(10); }); 
        }
    }
}