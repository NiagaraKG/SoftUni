CREATE PROC usp_GetHoldersFullName AS
BEGIN SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM dbo.AccountHolders END

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@amount MONEY) AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name] FROM dbo.AccountHolders AS ah
	JOIN dbo.Accounts AS a ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName HAVING SUM(a.Balance) > @amount ORDER BY FirstName, LastName
END

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL (18,4) , @rate FLOAT, @years INT) RETURNS DECIMAL (18,4) 
AS BEGIN DECLARE @FV DECIMAL (18,4) SET @FV = (@sum * (POWER((1 + @rate), @years))) RETURN @FV END

CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT) 
AS
BEGIN
	SELECT a.Id, ah.FirstName, ah.LastName, a.Balance 
	AS [Current Balance], dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) 
	AS [Balance in 5 years] FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountId
END

CREATE FUNCTION ufn_CashInUsersGames(@name NVARCHAR(50)) RETURNS MONEY AS
BEGIN
	DECLARE @sum MONEY; SET @sum = (SELECT SUM(s.Cash) AS SumCash FROM
	(SELECT ug.Cash, ROW_NUMBER() OVER (ORDER BY ug.Id DESC) AS [Row] FROM UsersGames AS ug
	JOIN Games AS g ON g.Id = ug.GameId WHERE g.[Name] = @name) AS s GROUP BY s.[Row] HAVING s.[Row] % 2 = 1)
	RETURN @sum
END