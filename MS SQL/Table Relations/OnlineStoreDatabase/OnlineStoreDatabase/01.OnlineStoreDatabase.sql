--CREATE DATABASE OnlineStore

CREATE TABLE [dbo].[Cities]
(
	CityID INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE [dbo].[Customers]
(
	CustomerID INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Cities](CityID)
)

CREATE TABLE [dbo].[Orders]
(
	OrderID INT IDENTITY(1, 1) PRIMARY KEY,
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Customers](CustomerID)
)

CREATE TABLE [dbo].[ItemTypes]
(
	ItemTypeID INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE [dbo].[Items]
(
	ItemID INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] VARCHAR(50),
	ItemTypeID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[ItemTypes](ItemTypeID)
)

CREATE TABLE [dbo].[OrderItems]
(
	OrderID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Orders](OrderID),
	ItemID INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Items](ItemID)

	PRIMARY KEY (OrderID, ItemID)
)