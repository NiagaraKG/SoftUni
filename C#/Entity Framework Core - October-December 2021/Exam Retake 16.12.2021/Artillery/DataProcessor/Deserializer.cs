namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Countries");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCountryDto[]), xmlRoot);
            StringReader sr = new StringReader(xmlString);
            ImportCountryDto[] countriesDtos = (ImportCountryDto[])xmlSerializer.Deserialize(sr);
            HashSet<Country> countries = new HashSet<Country>();
            foreach (var countryDto in countriesDtos)
            {
                if (!IsValid(countryDto)) { sb.AppendLine(ErrorMessage); continue; }
                var c = new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                };
                countries.Add(c);
                sb.AppendLine(String.Format(SuccessfulImportCountry, countryDto.CountryName, countryDto.ArmySize));
            }
            context.Countries.AddRange(countries);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static object DeserializeObject<T>(string v, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Manufacturers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportManufacturerDto[]), xmlRoot);
            StringReader sr = new StringReader(xmlString);
            ImportManufacturerDto[] manufacturerDtos = (ImportManufacturerDto[])xmlSerializer.Deserialize(sr);
            HashSet<Manufacturer> manufacturers = new HashSet<Manufacturer>();
            foreach (var manufacturerDto in manufacturerDtos)
            {
                if (!IsValid(manufacturerDto)) { sb.AppendLine(ErrorMessage); continue; }
                var m = new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };
                if (!manufacturers.Any(x => x.Founded == m.Founded && x.ManufacturerName == m.ManufacturerName))
                {
                    manufacturers.Add(m);
                }
                var f = manufacturerDto.Founded.Split(", ");
                var place = f[1] + ", " + f[2];
                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturerDto.ManufacturerName, place));
            }
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Shells");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportShellDto[]), xmlRoot);
            StringReader sr = new StringReader(xmlString);
            ImportShellDto[] shellDtos = (ImportShellDto[])xmlSerializer.Deserialize(sr);
            HashSet<Shell> shells = new HashSet<Shell>();
            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto)) { sb.AppendLine(ErrorMessage); continue; }
                var s = new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };
                shells.Add(s);                
                sb.AppendLine(String.Format(SuccessfulImportShell, shellDto.Caliber, shellDto.ShellWeight));
            }
            context.Shells.AddRange(shells);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportGunDto[] gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);
            HashSet<Gun> guns = new HashSet<Gun>();
            foreach (var gunDto in gunDtos)
            {
                if (!IsValid(gunDto)) { sb.AppendLine(ErrorMessage); continue; }
                if(!Enum.TryParse(gunDto.GunType, out GunType gunType)) { sb.AppendLine(ErrorMessage); continue; }
                var g = new Gun()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild =gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = gunType,
                    ShellId = gunDto.ShellId
                };
                HashSet<CountryGun> countries = new HashSet<CountryGun>();
                foreach (int countryId in gunDto.Countries.Distinct())
                {
                    Country country = context.Countries.Find(countryId);
                    if (country == null) { sb.AppendLine(ErrorMessage); continue; }
                    CountryGun c = new CountryGun()
                    {
                        Gun = g,
                        CountryId = countryId
                    };
                    countries.Add(c);
                }
                g.CountriesGuns = countries;
                guns.Add(g);
                sb.AppendLine(String.Format(SuccessfulImportGun, gunDto.GunType, gunDto.GunWeight, gunDto.BarrelLength));
            }
            context.Guns.AddRange(guns);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
