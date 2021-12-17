
namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static string RemoveTown(SoftUniContext context)
        {
            var townToRemove = context.Towns.FirstOrDefault(t => t.Name == "Seattle");
            var AddressesToDelete = context.Addresses.Where(a => a.TownId == townToRemove.TownId);
            var employeesToDelete = context.Employees.Where(e => AddressesToDelete.Any(a => a.AddressId == e.AddressId));
            var countOfAddressRemoved = AddressesToDelete.Count();
            foreach (var employee in employeesToDelete) { employee.AddressId = null; }
            foreach (var address in AddressesToDelete) { context.Addresses.Remove(address); }
            context.Towns.Remove(townToRemove);
            context.SaveChanges();
            return $"{countOfAddressRemoved} addresses in Seattle were deleted";
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.FirstOrDefault(p => p.ProjectId == 2);
            var employeeProject = context.EmployeesProjects.Where(p => p.EmployeeId == 2).ToList();
            foreach (var p in employeeProject) { context.EmployeesProjects.Remove(p); }
            context.Projects.Remove(project);
            context.SaveChanges();
            var sb = new StringBuilder();
            var projects = context.Projects.Select(p => p.Name).Take(10).ToList();
            foreach (var p in projects) { sb.AppendLine($"{p}"); }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees.Where(x => EF.Functions.Like(x.FirstName, "sa%"))
                .Select(x => new { x.FirstName, x.LastName, x.JobTitle, x.Salary })
                .OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var employees = context.Employees.Where(x => departments.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                e.Salary *= 1.12m;
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects.OrderByDescending(p => p.StartDate)
                .Take(10).OrderBy(p => p.Name).Select(p => new
                { name = p.Name, description = p.Description, startDate = p.StartDate }).ToList();
            var result = new StringBuilder();
            foreach (var project in latestProjects)
            {
                result.AppendLine($"{project.name}");
                result.AppendLine($"{project.description}");
                result.AppendLine($"{project.startDate}");
            }
            return result.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments.Where(x => x.Employees.Count > 5).OrderBy(x => x.Employees.Count).ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Manager.FirstName,
                    x.Manager.LastName,
                    Employees = x.Employees.Select(e => new { e.FirstName, e.LastName, e.JobTitle })
                .OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList()
                }).ToList();
            var sb = new StringBuilder();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.LastName} {d.FirstName} {d.LastName}");
                foreach (var e in d.Employees) { sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}"); }
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees.Select(x => new Employee
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                JobTitle = x.JobTitle,
                EmployeesProjects = x.EmployeesProjects.Select(p => new EmployeeProject { Project = p.Project }).OrderBy(p => p.Project.Name).ToList()
            }).FirstOrDefault(x => x.EmployeeId == 147);
            var sb = new StringBuilder();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var p in employee.EmployeesProjects) { sb.AppendLine($"{p.Project.Name}"); }
            return sb.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses.Select(x => new { x.AddressText, EmployeesCount = x.Employees.Count, Town = x.Town.Name })
                .OrderByDescending(x => x.EmployeesCount).ThenBy(x => x.Town).ThenBy(x => x.AddressText).Take(10).ToList();
            var sb = new StringBuilder();
            foreach (var a in addresses)
            { sb.AppendLine($"{a.AddressText}, {a.Town} - {a.EmployeesCount} employees"); }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees.Include(x => x.EmployeesProjects).ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFirstName = x.FirstName,
                    EmployeeLastName = x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                })
                .Take(10).ToList();
            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    if (p.EndDate.HasValue) { sb.AppendLine($"--{p.ProjectName } - {p.StartDate} - {p.EndDate}"); }
                    else { sb.AppendLine($"--{p.ProjectName } - {p.StartDate} - not finished"); }
                }
            }
            return sb.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var a = new Address { AddressText = "Vitoshka 15", TownId = 4 };
            context.Addresses.Add(a);
            context.SaveChanges();
            var e = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            e.AddressId = a.AddressId;
            context.SaveChanges();
            var addresses = context.Employees.Select(x => new { x.Address.AddressText, x.Address.AddressId })
                .OrderByDescending(x => x.AddressId).Take(10).ToList();
            var sb = new StringBuilder();
            foreach (var curr in addresses) { sb.AppendLine(curr.AddressText); }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new { x.FirstName, x.LastName, x.Department, x.Salary })
                .Where(x => x.Department.Name == "Research and Development").OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName).ToList();
            var sb = new StringBuilder();
            foreach (var e in employees)
            { sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}"); }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new { x.FirstName, x.Salary })
                .Where(x => x.Salary > 50000).OrderBy(x => x.FirstName).ToList();
            var sb = new StringBuilder();
            foreach (var e in employees) { sb.AppendLine($"{e.FirstName} - {e.Salary:f2}"); }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.MiddleName,
                x.JobTitle,
                x.Salary,
                x.EmployeeId
            }).OrderBy(x => x.EmployeeId).ToList();
            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static void Main(string[] args)
        {
            var softUniContext = new SoftUniContext();
            var result = RemoveTown(softUniContext);
            Console.WriteLine(result);
        }
    }
}
