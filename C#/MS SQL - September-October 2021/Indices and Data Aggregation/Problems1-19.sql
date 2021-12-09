SELECT COUNT(*) AS [Count] FROM WizzardDeposits

SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits GROUP BY DepositGroup

SELECT TOP (2) DepositGroup FROM WizzardDeposits GROUP BY DepositGroup ORDER BY AVG(MagicWandSize)

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits GROUP BY DepositGroup

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits 
WHERE MagicWandCreator = 'Ollivander family' GROUP BY DepositGroup

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family' GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000 ORDER BY TotalSum DESC

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator ORDER BY MagicWandCreator, DepositGroup

SELECT AgeGroup , COUNT(AgeGroup) AS WizzardCountFROM FROM
(SELECT CASE 
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
END AS AgeGroup FROM WizzardDeposits) AS AgeGroupQuery GROUP BY AgeGroup

SELECT DISTINCT LEFT(FirstName, 1) AS FirstLetter FROM WizzardDeposits WHERE DepositGroup = 'Troll Chest'

SELECT DepositGroup, IsDepositExpired,  AVG(DepositInterest) FROM WizzardDeposits WHERE DepositStartDate > '1985-01-01' 
GROUP BY IsDepositExpired, DepositGroup ORDER BY DepositGroup DESC, IsDepositExpired

SELECT SUM([Host Wizard Deposit] - [Guest Wizard Deposit]) AS SumDifference FROM
(SELECT FirstName AS [Host Wizzard], DepositAmount AS [Host Wizard Deposit],
LEAD (FirstName) OVER ( ORDER BY Id) AS [Guest Wizard],
LEAD (DepositAmount) OVER (ORDER By id) AS [Guest Wizard Deposit] FROM WizzardDeposits) AS DepositTable

SELECT DepartmentID, SUM(Salary) AS [TotalSalary] FROM Employees GROUP BY DepartmentID ORDER BY DepartmentID

SELECT DepartmentID, MIN(Salary) AS [MinimumSalary] FROM Employees
WHERE HireDate > '2000-01-01' AND DepartmentID IN (2,5,7) GROUP BY DepartmentID

SELECT * INTO AverageSalary FROM Employees WHERE Salary > 30000 
DELETE FROM AverageSalary WHERE ManagerID = 42
UPDATE AverageSalary SET Salary += 5000 WHERE DepartmentID = 1
SELECT DepartmentID , AVG(Salary) AS [AverageSalary] FROM AverageSalary GROUP BY DepartmentID

SELECT DepartmentID, MAX(Salary) AS [MaxSalary] FROM Employees 
GROUP BY DepartmentID HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

SELECT COUNT(EmployeeID) AS [Count] FROM Employees WHERE ManagerID IS NULL

SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary FROM
(SELECT DepartmentID, Salary,  DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY  Salary DESC) AS SalaryRank
FROM Employees) AS RankingQuery WHERE SalaryRank = 3

SELECT TOP(10)FirstName , LastName , e.DepartmentID  FROM Employees AS e
JOIN (SELECT DepartmentID, AVG (Salary) AS AvgSalary FROM Employees
GROUP BY DepartmentID) AS q ON e.DepartmentID = q.DepartmentID WHERE e.Salary > q.AvgSalary ORDER BY DepartmentID