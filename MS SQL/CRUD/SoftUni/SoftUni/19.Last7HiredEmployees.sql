SELECT TOP(7)
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName],
	[dbo].[Employees].[HireDate]
FROM
	[dbo].[Employees]
ORDER BY
	[dbo].[Employees].[HireDate] DESC