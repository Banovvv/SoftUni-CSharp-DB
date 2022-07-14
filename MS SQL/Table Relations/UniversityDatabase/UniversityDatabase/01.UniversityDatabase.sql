--CREATE DATABASE University

CREATE TABLE [dbo].[Subjects]
(
	SubjectID INT IDENTITY(1, 1) PRIMARY KEY,
	SubjectName NVARCHAR(25) NOT NULL
)

CREATE TABLE [dbo].[Majors]
(
	MajorID INT IDENTITY(100, 1) PRIMARY KEY,
	[Name] NVARCHAR(25) NOT NULL
)

CREATE TABLE [dbo].[Students]
(
	StudentID INT IDENTITY(1, 1) PRIMARY KEY,
	StudentNumber INT NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajodID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Majors](MajorID)
)

CREATE TABLE [dbo].[Agenda]
(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Students](StudentID),
	SubjectID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Subjects](SubjectID)

	PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE [dbo].[Payments]
(
	PaymentID INT IDENTITY(10000, 1) PRIMARY KEY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(10,2) NOT NULL,
	StudentID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Students](StudentID)
)