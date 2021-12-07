--CREATE DATABASE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Employees 
(FirstName, LastName, Title)
VALUES
('Ivan', 'Kirilov', 'CEO'),
('Anastasia', 'Hristova', 'CFO'),
('Katerina', 'Petrova', 'CTO')

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName VARCHAR(90) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Customers 
(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES
(1210, 'Svetlin', 'Georgiev', 0886302497, 'Ivelina Georgieva', 0886302498),
(1211, 'Radostina', 'Tsvetkova', 0885440271, 'Velislava Tsvetkov', 0885440270),
(1212, 'Georgi', 'Karavelov', 0893105123, 'Petar Karavelov', 0893105122)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO RoomStatus (RoomStatus) VALUES ('Cleaning'), ('Free'), ('Occupied')

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO RoomTypes (RoomType) VALUES ('Regular'), ('Business'), ('Luxury')

CREATE TABLE BedTypes
(
	BedType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO BedTypes (BedType) VALUES ('Regular'), ('Business'), ('Luxury')

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT NOT NULL,
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus)
VALUES 
(101, 'Luxury','Luxury', 20, 'Free'),
(102, 'Business','Business', 15, 'Occupied'),
(103, 'Regular','Regular', 10, 'Cleaning')

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15,2) NOT NULL,
	TaxRate INT NOT NULL,
	TaxAmount INT NOT NULL,
	PaymentTotal DECIMAL(15,2) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Payments 
(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays,
AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES 
(1, '2021-04-15', 123, '2021-04-15', '2021-04-20', 5, 50, 4, 20, 70),
(2, '2021-08-23', 479, '2021-08-23', '2021-08-27', 5, 50, 4, 20, 70),
(3, '2021-10-06', 385, '2021-10-06', '2021-10-06', 5, 50, 4, 20, 70)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT NOT NULL,
	PhoneCharge DECIMAL(15,2) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Occupancies
(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES
(1, '2021-04-15', 123, 1, 20, 10),
(2, '2021-08-23', 479, 2, 20, 10),
(3, '2021-10-06', 385, 3, 20, 10)
