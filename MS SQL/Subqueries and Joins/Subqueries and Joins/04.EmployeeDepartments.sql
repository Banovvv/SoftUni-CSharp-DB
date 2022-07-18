SELECT TOP(5)
	[dbo].[Employees].[EmployeeID],
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[Salary],
	[dbo].[Departments].[Name]
FROM
	[dbo].[Employees]
INNER JOIN
	[dbo].[Departments]
	ON [dbo].[Departments].[DepartmentID] = [dbo].[Employees].[DepartmentID]
WHERE
	[dbo].[Employees].[Salary] > 15000
ORDER BY
	[dbo].[Departments].[DepartmentID] ASC