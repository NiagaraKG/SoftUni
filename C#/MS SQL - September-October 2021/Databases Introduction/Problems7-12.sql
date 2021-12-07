/*CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARCHAR(MAX),
	Height DECIMAL(5,2),
	[Weight] DECIMAL(5,2),
	Gender VARCHAR(1) NOT NULL,
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX)
)
INSERT INTO PEOPLE 
([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Ana', 'https://i.pinimg.com/originals/19/9e/d9/199ed9b0fba7df539c9ca2bc366ac855.jpg', 1.7, 52, 'f', '2001-08-24', 'No Biography'),
('Dawn', 'https://i.pinimg.com/originals/19/9e/d9/199ed9b0fba7df539c9ca2bc366ac855.jpg', 1.68, 48, 'f', '2001-04-15', 'No Biography'),
('Peter', 'https://i.pinimg.com/originals/33/23/0e/33230ef6b773a018c0dc62d54f4d2b93.jpg', 1.8, 70, 'm', '2001-12-08', 'No Biography'),
('Willow', 'https://i.pinimg.com/originals/19/9e/d9/199ed9b0fba7df539c9ca2bc366ac855.jpg', 1.6, 43, 'f', '2001-03-21', 'No Biography'),
('Luke', 'https://i.pinimg.com/originals/33/23/0e/33230ef6b773a018c0dc62d54f4d2b93.jpg', 1.8, 70, 'm', '2001-07-01', 'No Biography')
*/

/*CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)
INSERT INTO Users 
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Ana', 'strongpass1', 'https://i.pinimg.com/originals/19/9e/d9/199ed9b0fba7df539c9ca2bc366ac855.jpg', '2021-09-24', 0),
('Dawn', '123456', 'https://i.pinimg.com/originals/19/9e/d9/199ed9b0fba7df539c9ca2bc366ac855.jpg', '2021-09-15', 0),
('Peter', 'my_pass', 'https://i.pinimg.com/originals/33/23/0e/33230ef6b773a018c0dc62d54f4d2b93.jpg', '2021-09-08', 0),
('Willow', 'passWORLD', 'https://i.pinimg.com/originals/19/9e/d9/199ed9b0fba7df539c9ca2bc366ac855.jpg', '2021-09-21', 0),
('Luke', '00000', 'https://i.pinimg.com/originals/33/23/0e/33230ef6b773a018c0dc62d54f4d2b93.jpg', '2021-09-11', 0)
*/

/*ALTER TABLE USERS
DROP CONSTRAINT PK__Users__3214EC07AB16A94D
ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username)*/

/*ALTER TABLE Users
ADD CONSTRAINT CH_PassLength CHECK (LEN([Password]) >= 5)*/

/*ALTER TABLE Users
ADD CONSTRAINT DF_LoginTime DEFAULT GETDATE() FOR LastLoginTime*/

/*ALTER TABLE USERS
DROP CONSTRAINT PK_IdUsername
ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)
ALTER TABLE Users
ADD CONSTRAINT CH_UsernameLength CHECK (LEN(Username) >= 3)*/

