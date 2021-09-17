using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        public List<Car> Cars { get; set; }
        public Parking(int capacity) { this.capacity = capacity; this.Cars = new List<Car>(); }
        public int Count => this.Cars.Count;
        public string AddCar(Car car)
        {
            foreach (var c in Cars)
            {
                if (c.RegistrationNumber == car.RegistrationNumber) { return "Car with that registration number, already exists!"; }
            }
            if (Cars.Count >= capacity) { return "Parking is full!"; }
            Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                if (Cars[i].RegistrationNumber == registrationNumber)
                {
                    Cars.RemoveAt(i);
                    return $"Successfully removed {registrationNumber}";                    
                }
            }
            return "Car with that registration number, doesn't exist!";
        }
        public Car GetCar(string registrationNumber)
        {
            foreach (var c in Cars)
            {
                if (c.RegistrationNumber == registrationNumber) { return c; }
            }
            return new Car();
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers) 
        { 
            foreach (var n in registrationNumbers) { RemoveCar(n); } 
        }               
    }
}

