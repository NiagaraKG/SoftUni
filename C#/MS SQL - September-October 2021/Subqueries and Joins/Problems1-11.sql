SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText 
FROM Employees AS e LEFT JOIN  Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID 

SELECT TOP(50) e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText FROM Employees AS e 
LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID LEFT JOIN Towns AS t ON A.TownID = T.TownID
ORDER BY e.FirstName, e.LastName

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS DepartmentName FROM Employees AS e 
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales' ORDER BY e.EmployeeID

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS DepartmentName FROM Employees AS e 
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE E.Salary > 15000 ORDER BY d.DepartmentID

SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL ORDER BY e.EmployeeID

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance') AND e.HireDate > '01-01-1999' ORDER BY e.HireDate

SELECT TOP(5) e.EmployeeID, e.FirstName,p.[Name] AS ProjectName FROM Employees AS e 
INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '08-13-2002' AND p.EndDate IS NULL ORDER BY e.EmployeeID

SELECT TOP(5) e.EmployeeID, e.FirstName,
	CASE 
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END AS ProjectName
FROM Employees AS e 
INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName AS ManagerName FROM Employees AS e
FULL OUTER JOIN Employees AS em ON e.ManagerID = em.EmployeeID
WHERE e.ManagerID IN (3,7) ORDER BY e.EmployeeID

SELECT TOP(50) e.EmployeeID, (e.FirstName + ' ' + E.LastName) AS EmployeeName,
(em.FirstName + ' ' + em.LastName) AS ManagerName, d.[name] AS DepartmentName FROM Employees AS e
FULL OUTER JOIN Employees AS em ON e.ManagerID = em.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

SELECT TOP(1) MinAverageSalary FROM (SELECT DepartmentID, AVG(Salary) AS MinAverageSalary FROM Employees
GROUP BY DepartmentID) AS SalaryAverage ORDER BY MinAverageSalary