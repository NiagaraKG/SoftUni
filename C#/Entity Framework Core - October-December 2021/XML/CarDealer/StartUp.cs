using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.DataTransferObjects.Output;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var supplierXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var partXml = File.ReadAllText("../../../Datasets/parts.xml");
            var carXml = File.ReadAllText("../../../Datasets/cars.xml");
            var saleXml = File.ReadAllText("../../../Datasets/sales.xml");
            var customerXml = File.ReadAllText("../../../Datasets/customers.xml");
            ImportSuppliers(context, supplierXml);
            ImportParts(context, partXml);
            ImportCars(context, carXml);
            ImportCustomers(context, customerXml);
            ImportSales(context, saleXml);
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            var textRead = new StringReader(inputXml);
            var suppliersDto = xmlSerializer.Deserialize(textRead) as SupplierInputModel[];
            var suppliers = suppliersDto.Select(x => new Supplier
            { Name = x.Name, IsImporter = x.IsImporter }).ToList();
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));
            var textReader = new StringReader(inputXml);
            var partsDto = xmlSerializer.Deserialize(textReader) as PartInputModel[];
            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();
            var parts = partsDto.Where(s => supplierIds.Contains(s.SupplierId)).Select(x => new Part
            { Name = x.Name, Price = x.Price, Quantity = x.Quantity, SupplierId = x.SupplierId }).ToList();
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            var textReader = new StringReader(inputXml);
            var carsDto = xmlSerializer.Deserialize(textReader) as CarInputModel[];
            var cars = new List<Car>();
            var partCars = new List<PartCar>();
            foreach (var c in carsDto)
            {
                var car = new Car()
                { Make = c.Make, Model = c.Model, TravelledDistance = c.TravelledDistance };
                var distinctPart = c.Parts.Where(pc => context.Parts.Any(x => x.Id == pc.PartId))
                    .Select(pc => pc.PartId).Distinct();
                foreach (var p in distinctPart)
                {
                    PartCar partcar = new PartCar { PartId = p, Car = car, };
                    partCars.Add(partcar);
                }
                cars.Add(car);
            }
            context.PartCars.AddRange(partCars);
            context.Cars.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {context.Cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {

            var xmlSerializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));
            var textReader = new StringReader(inputXml);
            var customersDto = xmlSerializer.Deserialize(textReader) as CustomerInputModel[];
            var customers = customersDto.Select(c => new Customer
            { Name = c.Name, BirthDate = c.BirthDate, IsYoungDriver = c.IsYoungDriver, }).ToList();
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SalesInputModel[]), new XmlRootAttribute("Sales"));
            var salesDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as SalesInputModel[];
            var sales = salesDto.Select(s => new Sale
            { CarId = s.CarId, CustomerId = s.CustomerId, Discount = s.Discount, })
                .Where(c => context.Cars.Any(i => i.Id == c.CarId)).ToList();
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarOutputModel
                { Make = c.Make, Model = c.Model, TravelledDistance = c.TravelledDistance })
                .OrderBy(m => m.Make).ThenBy(m => m.Model).Take(10).ToArray();
            var xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute("cars"));
            var stringWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(stringWriter, cars, ns);
            var result = stringWriter.ToString();
            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars.Where(c => c.Make == "BMW").OrderBy(m => m.Model)
                .ThenByDescending(t => t.TravelledDistance).Select(x => new BmwOutputModel
                { Id = x.Id, Model = x.Model, TravelledDistance = x.TravelledDistance }).ToArray();
            var xmlSerializer = new XmlSerializer(typeof(BmwOutputModel[]), new XmlRootAttribute("cars"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(stringWriter, bmwCars, namespaces);
            var result = stringWriter.ToString().TrimEnd();
            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierOutputModel
                { Id = s.Id, Name = s.Name, PartsCount = s.Parts.Count }).ToArray();
            var xmlSerializer = new XmlSerializer(typeof(LocalSupplierOutputModel[]), new XmlRootAttribute("suppliers"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(stringWriter, suppliers, namespaces);
            var result = stringWriter.ToString().TrimEnd();
            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars.Select(c => new CarWithPartsOutputModel
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                Parts = c.PartCars.Select(p => new PartDto
                { Name = p.Part.Name, Price = p.Part.Price }).OrderByDescending(p => p.Price).ToArray()
            }).OrderByDescending(x => x.TravelledDistance).ThenBy(x => x.Model).Take(5).ToArray();
            var xmlSerializer = new XmlSerializer(typeof(CarWithPartsOutputModel[]), new XmlRootAttribute("cars"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(stringWriter, carsWithParts, namespaces);
            var result = stringWriter.ToString().TrimEnd();
            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers.ToArray().Where(x => x.Sales.Any(y => y.CustomerId == x.Id))
                .Select(x => new TotalSalesOutputModel
                {
                    CustomerName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
                }).OrderByDescending(c => c.SpentMoney).ToArray();
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer xml = new XmlSerializer(typeof(TotalSalesOutputModel[]), new XmlRootAttribute("customers"));
            xml.Serialize(new StringWriter(sb), customers, namespaces);
            return sb.ToString().Trim();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(x => new SalesWithDiscountOutputModel
            {
                CarItem = new CarAttributesOutputModel
                { Make = x.Car.Make, Model = x.Car.Model, TravelledDistance = x.Car.TravelledDistance },
                Discount = x.Discount,
                CustomerName = x.Customer.Name,
                Price = x.Car.PartCars.Sum(z => z.Part.Price),
                PriceWithDiscount = x.Car.PartCars.Sum(z => z.Part.Price) - (x.Car.PartCars.Sum(z => z.Part.Price)) * x.Discount * 1.0m / 100.0m
            }).ToArray();
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer xml = new XmlSerializer(typeof(SalesWithDiscountOutputModel[]), new XmlRootAttribute("sales"));
            xml.Serialize(new StringWriter(sb), sales, namespaces);
            return sb.ToString().Trim();
        }
    }
}