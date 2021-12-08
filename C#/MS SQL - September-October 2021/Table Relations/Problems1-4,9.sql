--CREATE DATABASE TableRelations

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY NOT NULL,
	PassportNumber VARCHAR(8) NOT NULL
)
INSERT INTO Passports (PassportID, PassportNumber) VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')
CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) NOT NULL UNIQUE
)
INSERT INTO Persons (FirstName, Salary, PassportID) VALUES
('Roberto', 43300, 102),
('Tom', 56100, 103),
('Yana', 60200, 101)

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(20) NOT NULL,
	EstablishedOn DATETIME NOT NULL
)
INSERT INTO Manufacturers ([Name], EstablishedOn) VALUES
('BMW', '1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1966-05-01')
CREATE TABLE Models
(
	ModelID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(20) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)
INSERT INTO Models (ModelID, [Name], ManufacturerID) VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(20) NOT NULL
)
INSERT INTO Students ([Name]) VALUES ('Mila'), ('Toni'), ('Ron')
CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)
INSERT INTO Exams (ExamID, [Name]) VALUES 
(101, 'SpringMVC'), 
(102, 'Neo4j'), 
(103, 'Oracle11g')
CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL
	PRIMARY KEY ([StudentID], [ExamID])
)
INSERT INTO StudentsExams (StudentID, ExamID) VALUES 
(1, 101), 
(1, 102), 
(2, 101),
(3, 103), 
(2, 102), 
(2, 103)

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] VARCHAR(20) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)
INSERT INTO Teachers ([Name], ManagerID) VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)


USE [Geography]
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m JOIN Peaks AS p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY Elevation DESC