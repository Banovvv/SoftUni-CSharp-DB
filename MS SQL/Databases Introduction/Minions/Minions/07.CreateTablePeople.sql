CREATE TABLE [dbo].[People]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO [dbo].[People]
([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])

VALUES
('Ivan', 2233, 1.88, 74.50, 'm', '1992-02-02', 'Robot 1'),
('Dragan', 1132, 1.60, 44.00, 'm', '1993-03-03', 'Robot 2'),
('Petkan', 1323, 1.56, 66.66, 'm', '1994-04-04', 'Robot 3'),
('Georgi', 550, 1.95, 95.00, 'm', '1995-05-05', 'Robot 4'),
('Stamat', 1250, 1.16, 90.00, 'm', '1996-06-06', 'Robot 5');