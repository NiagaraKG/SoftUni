--CREATE DATABASE CarRental

CREATE TABLE Categories 
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(200) NOT NULL,
	DailyRate DECIMAL(5,2) NOT NULL,
	WeeklyRate DECIMAL(5,2) NOT NULL,
	MonthlyRate DECIMAL(5,2) NOT NULL,
	WeekendlyRate DECIMAL(5,2) NOT NULL
)
INSERT INTO Categories 
(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendlyRate)
VALUES
('Economy', 10, 50, 200, 15),
('Standart', 15, 75, 300, 25),
('Luxury', 20, 100, 400, 30)

CREATE TABLE Cars 
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(8) NOT NULL,
	Manufacturer NVARCHAR(200) NOT NULL,
	Model NVARCHAR(200) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARCHAR(MAX) NOT NULL,
	Condition NVARCHAR(200) NOT NULL,
	Available BIT NOT NULL
)
INSERT INTO Cars 
(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
('AC1264MN', 'Opel', 'Astra', 2001, 1, 5, 'pictureURL', 'Good', 1),
('ZX9814RL', 'Mazda', 'RX-8', 2007, 3, 3, 'pistureURL', 'Excellent', 0),
('KP7360JS', 'Lada', 'Niva', 2004, 2, 3, 'picctureURL', 'Good', 1)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(200) NOT NULL,
	Notes NVARCHAR(200)
)
INSERT INTO Employees (FirstName, LastName, Title)
VALUES
('Ivan', 'Ivanov', 'salesman'),
('Bogdana', 'Hristova', 'manager'),
('Svetoslav', 'Grigorov', 'accountant')

CREATE TABLE Customers 
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber NVARCHAR(9) NOT NULL,
	FullName NVARCHAR(200) NOT NULL,
	Adress NVARCHAR(MAX) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(200)
)
INSERT INTO Customers 
(DriverLicenceNumber, FullName, Adress, City, ZIPCode)
VALUES
('245136978', 'Katerina Vasileva', 'Svoboda str. 5', 'Plovdiv', '4000'),
('102497256', 'Lilia Stoyanova', 'Slaviani str 8', 'Pleven', '5800'),
('568203941', 'Mihail Tsvetanov', 'Rila str 11', 'Varna', '9000')

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied NVARCHAR(50) NOT NULL, 
	TaxRate DECIMAL(5,2) NOT NULL,
	OrderStatus NVARCHAR(50) NOT NULL, 
	Notes NVARCHAR(200), 
)
INSERT INTO RentalOrders 
(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus)
VALUES
(1, 1, 1, 40, 15000, 16000, 1000, '2021-04-15', '2021-05-15', 30, 'Standart', 300, 'Active'),
(2, 2, 2, 45, 10000, 11000, 1000, '2021-07-01', '2021-07-08', 7, 'Luxury', 100, 'Active'),
(3, 3, 3, 43, 20000, 21000, 1000, '2021-12-08', '2021-12-10', 2, 'Economy', 15, 'Active')