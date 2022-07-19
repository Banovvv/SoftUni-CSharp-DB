SELECT TOP(5)
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName]
FROM
	[dbo].[Employees]
ORDER BY
	[dbo].[Employees].[Salary] DESC