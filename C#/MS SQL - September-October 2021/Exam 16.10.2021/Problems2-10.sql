INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town, Country, Streat, ZIP) VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

GO

UPDATE Cigars
SET PriceForSingleCigar = 1.2 * PriceForSingleCigar
WHERE TastId = (SELECT Id FROM Tastes WHERE TasteType = 'Spicy')

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL
GO

--ClientCigars, Clients, Addresses  country C%
DELETE FROM ClientsCigars WHERE ClientId IN (SELECT Id FROM Clients WHERE AddressId IN (SELECT Id FROM Addresses WHERE Country LIKE 'C%'))
DELETE FROM Clients WHERE AddressId IN (SELECT Id FROM Addresses WHERE Country LIKE 'C%')
DELETE FROM Addresses WHERE Country LIKE 'C%'

GO
--05.
SELECT CigarName, PriceForSingleCigar, ImageURL FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC
GO

--06.
SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength
FROM Cigars AS c JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY PriceForSingleCigar DESC
GO

--07.
SELECT c.Id, c.FirstName + ' ' + c.LastName AS ClientName, c.Email
FROM Clients AS c LEFT JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
WHERE cc.CigarId IS NULL ORDER BY ClientName
GO

--08.
SELECT TOP(5) c.CigarName, c.PriceForSingleCigar, c.ImageURL FROM Cigars AS c
JOIN Sizes AS s ON c.SizeId = s.Id
WHERE ((s.Length >= 12) AND (c.CigarName LIKE '%ci%'
OR c.PriceForSingleCigar > 50) AND (s.RingRange > 2.55))
ORDER BY c.CigarName, c.PriceForSingleCigar DESC
GO 

--09.
SELECT c.FirstName + ' ' + c.LastName AS FullName, a.Country, a.ZIP,
'$' + CAST(MAX(cig.PriceForSingleCigar) AS VARCHAR(15)) AS CigarPrice
FROM Clients AS c JOIN Addresses AS a ON c.AddressId = a.Id
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id JOIN Cigars AS cig ON cc.CigarId = cig.Id
WHERE ISNUMERIC(a.ZIP) = 1
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP ORDER BY FullName

--10.
SELECT c.LastName, AVG(s.Length) AS CigarLength, CEILING(AVG(s.RingRange)) AS CigarRingRange
FROM Clients AS c JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS cig ON cc.CigarId = cig.Id JOIN Sizes AS s ON cig.SizeId = s.Id
WHERE cc.CigarId IS NOT NULL GROUP BY c.LastName ORDER BY CigarLength DESC

