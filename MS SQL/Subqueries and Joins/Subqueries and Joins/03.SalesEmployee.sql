SELECT
	[dbo].[Employees].[EmployeeID],
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName],
	[dbo].[Departments].[Name]
FROM
	[dbo].[Employees]
INNER JOIN
	[dbo].[Departments]
	ON [dbo].[Departments].[DepartmentID] = [dbo].[Employees].[DepartmentID]
WHERE
	[dbo].[Employees].[DepartmentID] = 3
ORDER BY
	[dbo].[Employees].[EmployeeID] ASC


SELECT
	[dbo].[Employees].[EmployeeID],
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName],
	[dbo].[Departments].[Name]
FROM
	[dbo].[Employees]
INNER JOIN
	[dbo].[Departments]
	ON [dbo].[Departments].[DepartmentID] = [dbo].[Employees].[DepartmentID]
WHERE
	[dbo].[Departments].[Name] = 'Sales'
ORDER BY
	[dbo].[Employees].[EmployeeID] ASC