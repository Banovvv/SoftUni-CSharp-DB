CREATE TABLE [dbo].[Students]
(
	StudentID INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(15) NOT NULL
)

CREATE TABLE [dbo].[Exams]
(
	ExamID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] NVARCHAR(15) NOT NULL
)

CREATE TABLE [dbo].[StudentsExams]
(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Students](StudentID),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Exams](ExamID)

	PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO [dbo].[Students]
([Name])

VALUES
('Mila'),
('Toni'),
('Ron');

INSERT INTO [dbo].[Exams]
([Name])

VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g');

INSERT INTO [dbo].[StudentsExams]
([StudentID], [ExamID])

VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103);