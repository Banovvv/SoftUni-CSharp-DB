CREATE TABLE [dbo].[People]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Birthdate DATE NOT NULL
)

INSERT INTO [dbo].[People]
([Name], [Birthdate])

VALUES
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06'),
('Pesho', '2001-12-07'),
('Gosho', '1982-09-10'),
('Stamat', '2010-09-19'),
('Dragan', '2000-01-06'),
('Petkan', '2015-12-07'),
('Ofrey', '2012-09-10'),
('Vankata', '1610-09-19'),
('Chichaka', '1610-01-06');

SELECT
	[Name],
	DATEDIFF(YEAR, [Birthdate], SYSDATETIME()) AS [Age in Years],
	DATEDIFF(MONTH, [Birthdate], SYSDATETIME()) AS [Age in Months],
	DATEDIFF(DAY, [Birthdate], SYSDATETIME()) AS [Age in Days],
	DATEDIFF(MINUTE, [Birthdate], SYSDATETIME()) AS [Age in Minutes]
FROM [dbo].[People]