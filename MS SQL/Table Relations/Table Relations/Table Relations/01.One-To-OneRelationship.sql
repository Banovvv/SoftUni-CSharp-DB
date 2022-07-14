CREATE DATABASE TableRelations

CREATE TABLE [dbo].[Passports]
(
	PassportID INT IDENTITY(101, 1) PRIMARY KEY,
	PassportNumber NVARCHAR(10) NOT NULL
)

CREATE TABLE [dbo].[People]
(
	PersonID INT IDENTITY(1, 1) PRIMARY KEY,
	FirstName NVARCHAR(25) NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL,
	PassportID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Passports] (PassportID)
)

INSERT INTO [dbo].[Passports]
([PassportNumber])

VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2');

INSERT INTO [dbo].People
([FirstName], [Salary], [PassportID])

VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101);