SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Countries AS c
INNER JOIN MountainsCountries  AS mc ON c.CountryCode = mc.CountryCode
INNER JOIN Mountains AS m ON mc.MountainId = m.Id INNER JOIN Peaks AS p ON m.Id = p.MountainId
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835 ORDER BY  p.Elevation DESC

SELECT c.CountryCode , COUNT(c.CountryCode) FROM Countries AS  c 
INNER JOIN  MountainsCountries AS mc ON c.CountryCode = mc.CountryCode AND c.CountryCode IN ('BG','US','RU')
INNER JOIN Mountains AS m ON mc.MountainId = m.Id
GROUP BY c.CountryCode

SELECT TOP(5) c.CountryName, r.RiverName FROM Countries AS c 
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode 
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF' ORDER BY c.CountryName

SELECT ContinentCode ,CurrencyCode, CurCount AS CurrencyUsage FROM
(SELECT *, DENSE_RANK () OVER (PARTITION BY ContinentCode ORDER BY CurCount DESC ) AS  CurrencyRank
FROM (SELECT *FROM (SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurCount FROM Countries
GROUP BY ContinentCode, CurrencyCode) AS CurrencyCounter
WHERE CurCount > 1) AS SubQuerry) AS FinalQuerry WHERE CurrencyRank = 1 ORDER BY ContinentCode

SELECT COUNT(CountryName) AS [Count] FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode 
WHERE MountainId IS NULL

SELECT TOP(5) CountryName, HighestPeakElevation, LongestRiverLength FROM
(SELECT c.CountryName,MAX(p.Elevation) AS HighestPeakElevation, MAX(r.Length) AS LongestRiverLength
FROM Countries AS c 
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName) AS CountryInfo ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC

SELECT TOP(5) [Country], ISNULL([Highest Peak Name], '(no highest peak)') AS [Highest Peak Name] ,
ISNULL([Highest Peak Elevation] , 0)  AS [Highest Peak Elevation], 
ISNULL([Mountain], '(no mountain)') AS [Mountain] FROM 
(SELECT *, DENSE_RANK() OVER  (PARTITION BY [Country] ORDER BY [Highest Peak Elevation] ) AS PeakRank
FROM (SELECT c.CountryName AS [Country], P.PeakName AS [Highest Peak Name],
p.Elevation AS[Highest Peak Elevation], m.MountainRange AS [Mountain] FROM Countries AS c 
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id LEFT JOIN Peaks AS p ON m.Id = p.MountainId)
AS FirstQ) AS SecondQ WHERE PeakRank = 1