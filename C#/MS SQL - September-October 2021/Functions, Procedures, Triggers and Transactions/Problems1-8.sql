CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 AS
BEGIN SELECT FirstName, LastName FROM Employees WHERE Salary > 35000 END
GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@salary DECIMAL(18,4)) AS
BEGIN SELECT FirstName,LastName	FROM Employees WHERE Salary >= @salary END
GO

CREATE PROCEDURE usp_GetTownsStartingWith @start VARCHAR(50) AS
BEGIN SELECT [Name] FROM Towns WHERE LEFT([Name], LEN(@start)) = @start END
GO

CREATE PROC usp_GetEmployeesFromTown  @town VARCHAR(50) AS
BEGIN
	SELECT FirstName as [First Name], LastName as [Last Name] FROM Employees AS e
	INNER JOIN Addresses AS  d ON e.AddressID = d.AddressID
	INNER JOIN Towns AS t ON d.TownID = t.TownID
	WHERE t.[Name] = @town
END
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) RETURNS VARCHAR(8) AS
BEGIN
	DECLARE @level VARCHAR(8)
		IF @salary < 30000 BEGIN SET @level = 'Low' END
		ELSE IF @salary BETWEEN 30000 AND 50000 BEGIN SET @level = 'Average' END
		ELSE BEGIN SET @level = 'High' END
	RETURN @level
END
GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel (@Salary VARCHAR(8)) AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name] FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @Salary
END
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(200), @word NVARCHAR(50)) RETURNS INT AS
BEGIN
	DECLARE @count INT = 1;	DECLARE @letter NVARCHAR
	WHILE @count <= LEN(@word)
	BEGIN		
		SET @letter = SUBSTRING(@word, @count, 1)
		IF @setOfLetters NOT LIKE '%' + @letter + '%' RETURN 0
		SET @count += 1
	END
	RETURN 1
END
GO

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
	UPDATE Employees SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
	ALTER TABLE Departments ALTER COLUMN ManagerId INT
	UPDATE Departments SET ManagerID = NULL WHERE DepartmentID = @departmentId
	DELETE FROM Employees WHERE DepartmentID = @departmentId
	DELETE FROM Departments WHERE DepartmentID = @departmentId
	SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId
END
GO