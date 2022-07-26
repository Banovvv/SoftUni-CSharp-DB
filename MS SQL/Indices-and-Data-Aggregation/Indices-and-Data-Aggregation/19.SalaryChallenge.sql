SELECT TOP(10)
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName],
	[dbo].[Employees].[DepartmentID]
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[Salary] > (SELECT
									AVG([e1].[Salary])
								  FROM
									[dbo].[Employees] AS [e1]
								  WHERE
									[dbo].[Employees].[DepartmentID] = [e1].[DepartmentID])
ORDER BY
	[dbo].[Employees].[DepartmentID]