USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(200) NOT NULL,
	Notes NVARCHAR(MAX),
)
INSERT INTO Directors 
([DirectorName])
VALUES
('Alfred Hitchcock'),
('Chad Stahelski'),
('Luc Besson'),
('Peter Jackson'),
('Patrick Hughes')

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(200) NOT NULL,
	Notes NVARCHAR(MAX),
)
INSERT INTO Genres 
([GenreName])
VALUES
('Horror'),
('Sci-fi'),
('Fantasy'),
('Action'),
('Comedy')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(200) NOT NULL,
	Notes NVARCHAR(MAX),
)
INSERT INTO Categories 
([CategoryName], Notes)
VALUES
('G', 'All ages admitted.'),
('PG', 'Some material may not be suitable for children.'),
('PG-13', 'Some material may be inappropriate for children under 13.'),
('R', 'Under 17 requiers accompaning parent or adult guardian.'),
('NC-17', 'No one 17 and under admitted')

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(200) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] DECIMAL NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT NOT NULL,
	Notes NVARCHAR(MAX),
)

ALTER TABLE [Movies]
ADD CONSTRAINT [FK_DIrector] FOREIGN KEY (DirectorId) REFERENCES [Directors]([Id])
ALTER TABLE [Movies]
ADD CONSTRAINT [FK_Genre] FOREIGN KEY (GenreId) REFERENCES [Genres]([Id])
ALTER TABLE [Movies]
ADD CONSTRAINT [FK_Category] FOREIGN KEY (CategoryId) REFERENCES [Categories]([Id])

INSERT INTO Movies 
(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating)
VALUES
('Psycho', 1, 1960, 1.82, 1, 5, 8.5),
('Lucy', 3, 2014, 1.5, 2, 4, 6.4),
('The Lord of the Rings: The Two Towers', 4, 2002, 3, 3, 2, 8.7),
('John Wick', 2, 2014, 1.68, 4, 3, 7.4),
('The Hitman`s Bodyguard', 5, 2017, 2, 5, 1, 6.9)