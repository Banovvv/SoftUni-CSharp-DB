SELECT
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName]
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[DepartmentID] <> 4