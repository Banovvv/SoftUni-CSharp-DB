SELECT TOP (1)
	AVG([dbo].[Employees].[Salary]) AS [Mininum Average Salary]
FROM
	[dbo].[Employees]
GROUP BY
	[dbo].[Employees].[DepartmentID]
ORDER BY
	[Mininum Average Salary] ASC