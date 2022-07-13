CREATE DATABASE Movies

CREATE TABLE [dbo].[Directors]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	DirectorName NVARCHAR(50),
	Notes NVARCHAR(150)
)

CREATE TABLE [dbo].[Genres]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	GenreName NVARCHAR(20),	
	Notes NVARCHAR(150)
)

CREATE TABLE [dbo].[Categories]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	CategoryName NVARCHAR(20),
	Notes NVARCHAR(150)
)

CREATE TABLE [dbo].[Movies]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Title NVARCHAR(50),
	DirectorId INT NOT NULL,
	CopyrightYear INT,
	[Length] TIME NOT NULL,
	GenreId INT NOT NULL,	
	CategoryId INT NOT NULL,	
	Rating INT CHECK (Rating > 0 AND Rating <=10),	
	Notes NVARCHAR(150)
)