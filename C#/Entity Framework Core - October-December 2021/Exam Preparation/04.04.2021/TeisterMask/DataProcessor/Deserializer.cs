namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), xmlRoot);
            StringReader sr = new StringReader(xmlString);
            ImportProjectDto[] projectDtos = (ImportProjectDto[])
                xmlSerializer.Deserialize(sr);
            HashSet<Project> projects = new HashSet<Project>();
            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto)) { sb.AppendLine(ErrorMessage); continue; }

                bool isOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDate);
                if (!isOpenDateValid) { sb.AppendLine(ErrorMessage); continue; }

                DateTime? dueDate = null;
                if (!String.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    bool isDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateValue);
                    if (!isDueDateValid) { sb.AppendLine(ErrorMessage); continue; }
                    dueDate = dueDateValue;
                }

                Project p = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                HashSet<Task> tasks = new HashSet<Task>();
                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto)) { sb.AppendLine(ErrorMessage); continue; }

                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);
                    if (!isTaskOpenDateValid) { sb.AppendLine(ErrorMessage); continue; }

                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                       CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);
                    if (!isTaskDueDateValid) { sb.AppendLine(ErrorMessage); continue; }


                    if (taskOpenDate < p.OpenDate) { sb.AppendLine(ErrorMessage); continue; }
                    if (p.DueDate.HasValue && taskDueDate > p.DueDate)
                    { sb.AppendLine(ErrorMessage); continue; }

                    Task t = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                    };
                    tasks.Add(t);
                }
                p.Tasks = tasks;
                projects.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, p.Name, tasks.Count));
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportEmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            HashSet<Employee> employees = new HashSet<Employee>();
            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto)) { sb.AppendLine(ErrorMessage); continue; }
                var e = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };
                HashSet<EmployeeTask> tasks = new HashSet<EmployeeTask>();
                foreach (int taskId in employeeDto.Tasks.Distinct())
                {
                    Task task = context.Tasks.Find(taskId);
                    if (task == null) { sb.AppendLine(ErrorMessage); continue; }
                    EmployeeTask t = new EmployeeTask()
                    {
                        Employee = e,
                        TaskId = taskId
                    };
                    tasks.Add(t);
                }
                e.EmployeesTasks = tasks;
                employees.Add(e);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, e.Username, tasks.Count));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}