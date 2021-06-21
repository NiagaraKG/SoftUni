using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        CarRepository carsRepository;
        DriverRepository driversRepository;
        RaceRepository racersRepository;

        public ChampionshipController()
        {
            carsRepository = new CarRepository();
            driversRepository = new DriverRepository();
            racersRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            Driver driver = (Driver)driversRepository.GetByName(driverName);
            if (driver == null) { throw new InvalidOperationException($"Driver {driverName} could not be found."); }
            Car car = (Car)carsRepository.GetByName(carModel);
            if (car == null) { throw new InvalidOperationException($"Car {carModel} could not be found."); }
            driver.AddCar(car);
            this.carsRepository.Remove(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            Race race = (Race)racersRepository.GetByName(raceName);
            if (race == null) { throw new InvalidOperationException($"Race {raceName} could not be found."); }
            Driver driver = (Driver)driversRepository.GetByName(driverName);
            if (driver == null) { throw new InvalidOperationException($"Driver {driverName} could not be found."); }
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carsRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            string t = "";
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
                t = "MuscleCar";
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
                t = "SportsCar";
            }
            carsRepository.Add(car);
            return $"{t} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            if (driversRepository.GetByName(driverName) != null)
            { throw new ArgumentException($"Driver {driverName} is already created."); }
            driversRepository.Add(new Driver(driverName));
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            Race race = (Race)racersRepository.GetByName(name);
            if (race != null) { throw new InvalidOperationException($"Race {name} is already create."); }
            race = new Race(name, laps);
            racersRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            Race race = (Race)racersRepository.GetByName(raceName);
            if (race == null) { throw new InvalidOperationException($"Race {raceName} could not be found."); }
            if (race.Drivers.Count < 3)
            { throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants."); }
            var drivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToArray();
            racersRepository.Remove(race);
            drivers[0].WinRace();
            return $"Driver {drivers[0].Name} wins {raceName} race." + Environment.NewLine
                + $"Driver {drivers[1].Name} is second in {raceName} race." + Environment.NewLine
                + $"Driver {drivers[2].Name} is third in {raceName} race.";
        }
    }
}
