SELECT
	[dbo].[Employees].[DepartmentID], 
    SUM([dbo].[Employees].[Salary]) as [Total Salary]
FROM
	[dbo].[Employees]
GROUP BY
	[dbo].[Employees].[DepartmentID]
ORDER BY
	[dbo].[Employees].[DepartmentID]