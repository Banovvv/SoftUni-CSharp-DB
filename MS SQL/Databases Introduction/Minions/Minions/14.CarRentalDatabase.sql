CREATE DATABASE CarRental

CREATE TABLE [dbo].[Categories]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL CHECK (DailyRate > 0),
	WeeklyRate DECIMAL CHECK (WeeklyRate > 0),
	MonthlyRate DECIMAL CHECK (MonthlyRate > 0),
	WeekendRate DECIMAL CHECK (WeekendRate > 0),
)

CREATE TABLE [dbo].[Cars]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	PlateNumber NVARCHAR(20),
	Manufacturer NVARCHAR(20),
	Model NVARCHAR(20),
	CarYear INT,
	CategoryId INT NOT NULL CHECK (CategoryId > 0),
	Doors INT CHECK (Doors >= 2 AND Doors <= 4),
	Picture VARBINARY(MAX),
	Condition NVARCHAR(20),
	Available BIT
)

CREATE TABLE [dbo].[Employees]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(150)
)

CREATE TABLE [dbo].[RentalOrders]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	EmployeeId INT NOT NULL CHECK (EmployeeId > 0),
	CustomerId INT NOT NULL CHECK (CustomerId > 0),
	CarId INT NOT NULL CHECK (CarId > 0),
	TankLevel INT CHECK (TankLevel >= 0 AND TankLevel <= 10),
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,	
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME,
	EndDate DATETIME,
	TotalDays INT,
	RateApplied NVARCHAR(50),
	TaxRate NVARCHAR(50),
	OrderStatus NVARCHAR(50),
	Notes NVARCHAR(150)
)