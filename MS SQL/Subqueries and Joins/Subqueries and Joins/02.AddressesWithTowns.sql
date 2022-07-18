SELECT TOP(50)
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName],
	[dbo].[Towns].[Name],
	[dbo].[Addresses].[AddressText]
FROM
	[dbo].[Employees]
INNER JOIN
	[dbo].[Addresses]
		ON [dbo].[Addresses].[AddressID] = [dbo].[Employees].[AddressID]
INNER JOIN
	[dbo].[Towns]
		ON [dbo].[Addresses].[TownID] = [dbo].[Towns].[TownID]
ORDER BY
	[dbo].[Employees].[FirstName] ASC,
	[dbo].[Employees].[LastName] ASC