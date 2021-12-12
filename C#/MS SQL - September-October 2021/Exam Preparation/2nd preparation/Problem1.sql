--CREATE DATABASE School

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK (Age>0),
	[Address] NVARCHAR(50),
	Phone NVARCHAR(10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL,
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL FOREIGN KEY (StudentId) REFERENCES Students(Id),
	SubjectId INT NOT NULL FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
	Grade DECIMAL(15,2) NOT NULL CHECK (Grade >= 2 AND Grade <= 6)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT NOT NULL FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
)

CREATE TABLE StudentsExams
(
	StudentId INT NOT NULL FOREIGN KEY (StudentId) REFERENCES Students(Id),
	ExamId INT NOT NULL FOREIGN KEY (ExamId) REFERENCES Exams(Id),
	Grade DECIMAL(15,2) NOT NULL CHECK (Grade >= 2 AND Grade <= 6),
	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone NVARCHAR(10),
	SubjectId INT NOT NULL FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers
(
	StudentId INT NOT NULL FOREIGN KEY (StudentId) REFERENCES Students(Id),
	TeacherId INT NOT NULL FOREIGN KEY (TeacherId) REFERENCES Teachers(Id),
	CONSTRAINT PK_StudentsTeachers PRIMARY KEY (StudentId, TeacherId)
)

