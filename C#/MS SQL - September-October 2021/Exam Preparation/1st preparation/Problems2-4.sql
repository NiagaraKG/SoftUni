INSERT INTO Planes ([Name], Seats, [Range]) VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes (Type) VALUES ('Crossbody Bag'), ('School Backpack'), ('Shoulder Bag')

--03.
UPDATE Tickets
SET Price = 1.13 * Price
WHERE FlightId = (SELECT Id FROM Flights WHERE Destination = 'Carlsbad')

--04.
DELETE FROM Tickets WHERE FlightId = (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim')
DELETE FROM Flights WHERE Destination = 'Ayn Halagim'