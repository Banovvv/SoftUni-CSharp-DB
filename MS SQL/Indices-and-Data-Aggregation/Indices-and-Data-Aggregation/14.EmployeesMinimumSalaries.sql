SELECT
	[Employees].[DepartmentID], 
	MIN(Salary) AS [Minimum Salary]
FROM
	[dbo].[Employees] AS [Employees]
WHERE
	[Employees].[DepartmentID] IN (2, 5, 7) AND
	[Employees].[HireDate] > '01-01-2000'
GROUP BY
	[Employees].[DepartmentID] 