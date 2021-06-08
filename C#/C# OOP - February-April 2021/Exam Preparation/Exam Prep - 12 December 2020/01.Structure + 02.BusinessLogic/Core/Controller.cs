using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal income = 0;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea") { drinks.Add(new Tea(name, portion, brand)); }
            if (type == "Water") { drinks.Add(new Water(name, portion, brand)); }
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Cake") { bakedFoods.Add(new Cake(name, price)); }
            else if (type == "Bread") { bakedFoods.Add(new Bread(name, price)); }
            else { throw new ArgumentException(); }
            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable") { tables.Add(new InsideTable(tableNumber, capacity)); }
            else if (type == "OutsideTable") { tables.Add(new OutsideTable(tableNumber, capacity)); }
            else { throw new ArgumentException(); }
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder s = new StringBuilder();
            foreach (var t in tables.Where(t => t.IsReserved == false))
            { s.AppendLine(t.GetFreeTableInfo()); }
            return s.ToString().TrimEnd();
        }

        public string GetTotalIncome() { return $"Total income: {income:f2}lv"; }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            this.income += bill;
            table.Clear();
            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null) { return $"Could not find table {tableNumber}"; }
            var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null) { return $"There is no {drinkName} {drinkBrand} available"; }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null) { return $"Could not find table {tableNumber}"; }
            var food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (food == null) { return $"No {foodName} in the menu"; }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            if (table == null) { return $"No available table for {numberOfPeople} people"; }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
