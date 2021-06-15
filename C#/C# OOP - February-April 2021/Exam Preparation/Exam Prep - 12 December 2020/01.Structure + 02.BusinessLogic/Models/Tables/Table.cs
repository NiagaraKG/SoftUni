using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        private int capacity, numberOfPeople;

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0) { throw new ArgumentException(ExceptionMessages.InvalidTableCapacity); }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value < 0) { throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople); }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber; this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IBakedFood>(); this.drinkOrders = new List<IDrink>();
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal sum = 0;
            foreach (var f in foodOrders) { sum += f.Price; }
            foreach (var d in drinkOrders) { sum += d.Price; }
            return sum + this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine($"Table: {this.TableNumber}");
            s.AppendLine($"Type: {this.GetType().Name}");
            s.AppendLine($"Capacity: {this.Capacity}");
            s.AppendLine($"Price per Person: {this.PricePerPerson}");
            return s.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink) { this.drinkOrders.Add(drink); }

        public void OrderFood(IBakedFood food) { this.foodOrders.Add(food); }

        public void Reserve(int numberOfPeople) { this.IsReserved = true; this.NumberOfPeople = numberOfPeople; }
    }
}
