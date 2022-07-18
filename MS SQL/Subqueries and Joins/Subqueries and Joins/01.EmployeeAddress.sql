SELECT TOP(5)
	[dbo].[Employees].[EmployeeId],
	[dbo].[Employees].[JobTitle],
	[dbo].[Employees].[AddressID],
	[dbo].[Addresses].[AddressText] 
FROM
	[dbo].[Employees]
INNER JOIN
	[dbo].[Addresses]
		ON [dbo].[Addresses].[AddressID] = [dbo].[Employees].[AddressID]
ORDER BY
	[dbo].[Addresses].[AddressID] ASC