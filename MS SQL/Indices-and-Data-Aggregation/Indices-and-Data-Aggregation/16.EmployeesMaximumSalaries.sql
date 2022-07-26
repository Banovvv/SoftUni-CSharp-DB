SELECT
	[dbo].[Employees].[DepartmentID],
	MAX([dbo].[Employees].[Salary])
FROM
	[dbo].[Employees]
GROUP BY
	[dbo].[Employees].[DepartmentID]
HAVING
	MAX([dbo].[Employees].[Salary]) >= 30000 AND
	MAX([dbo].[Employees].[Salary]) <= 70000