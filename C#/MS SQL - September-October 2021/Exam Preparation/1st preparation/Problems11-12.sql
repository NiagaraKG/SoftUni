CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT) 
RETURNS NVARCHAR(MAX) AS BEGIN
	IF (@peopleCount <= 0) RETURN 'Invalid people count!'
	DECLARE @isValidFlight INT;	
	SET @isValidFlight = (SELECT Id FROM Flights WHERE Destination = @destination AND Origin = @origin);
	IF (@isValidFlight IS NULL) RETURN 'Invalid flight!'
	DECLARE @flightId INT, @ticketPrice DECIMAL (15,2), @totalPrice DECIMAL (15, 2); 
	SET @flightId = (SELECT Id FROM Flights WHERE Origin = @origin);
	SET @ticketPrice = (SELECT Price FROM Tickets WHERE FlightId = @flightId);
	SET @totalPrice = @peopleCount * @ticketPrice;
	RETURN 'Total price ' +  CAST(@totalPrice as VARCHAR(10));
END
GO

--12.
CREATE PROCEDURE usp_CancelFlights AS
UPDATE Flights
SET DepartureTime = NULL, ArrivalTime = NULL
WHERE ArrivalTime > DepartureTime