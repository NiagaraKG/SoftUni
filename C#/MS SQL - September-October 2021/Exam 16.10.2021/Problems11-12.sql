CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) RETURNS INT AS BEGIN
	DECLARE @count INT;
	SET @count = (SELECT COUNT(cc.CigarId) 
	FROM Clients AS c LEFT JOIN ClientsCigars AS cc ON cc.ClientId = c.Id WHERE c.FirstName = @name)
	RETURN @count;	
END
GO

--12.
CREATE PROCEDURE usp_SearchByTaste @taste NVARCHAR(20) AS
SELECT c.CigarName, '$' + CAST(c.PriceForSingleCigar AS VARCHAR(15)) AS Price, t.TasteType, b.BrandName, 
CAST(s.[Length] AS VARCHAR(15)) + ' cm' AS CigarLength, 
CAST(s.RingRange AS VARCHAR(15)) + ' cm' AS CigarRingRange
FROM Cigars AS c JOIN Sizes AS s ON c.SizeId = s.Id 
JOIN Tastes AS t ON t.Id = c.TastId JOIN Brands AS b ON b.Id = c.BrandId
WHERE t.TasteType = @taste
ORDER BY CigarLength, CigarRingRange DESC