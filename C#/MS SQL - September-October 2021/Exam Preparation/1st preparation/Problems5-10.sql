SELECT * FROM Planes WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

--06.
SELECT FlightId, SUM(Price) AS Price FROM Tickets
GROUP BY FlightId ORDER BY Price DESC, FlightId

--07.
SELECT p.FirstName + ' ' + p.LastName AS [Full Name], f.Origin, f.Destination
FROM Passengers AS p JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
ORDER BY [Full Name], Origin, Destination

--08.
SELECT p.FirstName AS [First Name], p.LastName AS [Last Name], p.Age
FROM Passengers AS p LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.Id IS NULL ORDER BY Age DESC, [First Name], [Last Name]

--09.
SELECT p.FirstName + ' ' + p.LastName AS [Full Name],  pl.[Name] AS [Plane Name],
f.Origin + ' - ' + f.Destination AS 'Trip', lt.[Type] AS 'Luggage Type'
FROM Passengers AS p JOIN Tickets AS t ON t.PassengerId = p.Id 
JOIN Luggages AS l ON t.LuggageId = l.Id JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
JOIN Flights AS f ON t.FlightId = f.Id JOIN Planes AS pl ON f.PlaneId = pl.Id
ORDER BY [Full Name], [Plane Name], Origin, Destination, [Luggage Type]

--10.
SELECT pl.[Name], pl.Seats, COUNT(t.PassengerId) AS [Passangers Count] FROM Planes AS pl 
LEFT JOIN Flights AS f ON pl.Id = f.PlaneId LEFT JOIN Tickets AS t ON f.Id = t.FlightId
GROUP BY pl.[Name], pl.Seats ORDER BY [Passangers Count] DESC, [Name], Seats