SELECT
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName],
	[dbo].[Employees].[Salary]
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[Salary] >= 50000
ORDER BY
	[dbo].[Employees].[Salary] DESC