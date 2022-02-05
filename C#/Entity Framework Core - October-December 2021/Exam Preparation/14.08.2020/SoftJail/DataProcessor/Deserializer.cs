namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportDepartmentDto[] departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);
            HashSet<Department> departments = new HashSet<Department>();
            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto)) { sb.AppendLine("Invalid Data"); continue; }
                Department d = new Department() { Name = departmentDto.Name };
                bool areCellsValid = true;
                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto)) { areCellsValid = false; break; }
                    d.Cells.Add(new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }
                if (!areCellsValid) { sb.AppendLine("Invalid Data"); continue; }
                if (d.Cells.Count == 0) { sb.AppendLine("Invalid Data"); continue; }
                departments.Add(d);
                sb.AppendLine(String.Format("Imported {0} with {1} cells", d.Name, d.Cells.Count));
            }
            context.Departments.AddRange(departments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPrisonerDto[] prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);
            HashSet<Prisoner> prisoners = new HashSet<Prisoner>();
            foreach (var prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto)) { sb.AppendLine("Invalid Data"); continue; }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);
                if (!isIncarcerationDateValid) { sb.AppendLine("Invalid Data"); continue; }

                DateTime? releaseDate = null;
                if (!String.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);
                    if (!isReleaseDateValid) { sb.AppendLine("Invalid Data"); continue; }
                    releaseDate = releaseDateValue;
                }

                Prisoner p = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                bool areMailsValid = true;
                foreach (ImportMailDto mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto)) { areMailsValid = false; continue; }
                    p.Mails.Add(new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                if (!areMailsValid) { sb.AppendLine("Invalid Data"); continue; }

                prisoners.Add(p);
                sb.AppendLine(String.Format("Imported {0} {1} years old", p.FullName, p.Age));
            }
            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));
            HashSet<Officer> officers = new HashSet<Officer>();
            StringReader stringReader = new StringReader(xmlString);
            ImportOfficerDto[] officerDtos = (ImportOfficerDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var officerDto in officerDtos)
            {
                if (!IsValid(officerDto)) { sb.AppendLine("Invalid Data"); continue; }

                object positionObj;
                bool isPositionValid = Enum.TryParse(typeof(Position), officerDto.Position, out positionObj);
                if (!isPositionValid) { sb.AppendLine("Invalid Data"); continue; }

                object weaponObj;
                bool isWeaponValid = Enum.TryParse(typeof(Weapon), officerDto.Weapon, out weaponObj);
                if (!isWeaponValid) { sb.AppendLine("Invalid Data"); continue; }

                Officer o = new Officer()
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position = (Position)positionObj,
                    Weapon = (Weapon)weaponObj,
                    DepartmentId = officerDto.DepartmentId
                };

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    o.OfficerPrisoners.Add(new OfficerPrisoner()
                    { Officer = o, PrisonerId = prisonerDto.PrisonerId });
                }
                officers.Add(o);
                sb.AppendLine(String.Format("Imported {0} ({1} prisoners)", o.FullName, o.OfficerPrisoners.Count));
            }
            context.Officers.AddRange(officers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}