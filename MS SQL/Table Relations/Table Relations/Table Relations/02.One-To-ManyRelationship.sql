CREATE TABLE [dbo].[Manufacturers]
(
	ManufacturerID INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(15) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE [dbo].[Models]
(
	ModelID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] NVARCHAR(15) NOT NULL, 
	ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Manufacturers](ManufacturerID)
)

INSERT INTO [dbo].[Manufacturers]
([Name], [EstablishedOn])

VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO [dbo].[Models]
([Name], [ManufacturerID])

VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

SELECT * FROM Models