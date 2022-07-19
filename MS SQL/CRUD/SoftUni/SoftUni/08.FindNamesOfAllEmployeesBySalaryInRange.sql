SELECT
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName],
	[dbo].[Employees].[JobTitle]
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[Salary] >= 20000 AND
	[dbo].[Employees].[Salary] <= 30000 