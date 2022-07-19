SELECT
	[Employees].[EmployeeID],
	CONCAT([Employees].[FirstName], ' ', [Employees].[LastName]) AS [Employee Name],
	CONCAT([Managers].[FirstName], ' ', [Managers].[LastName]) AS [Manager Name],
	[Departments].[Name] AS [Department Name]
FROM
	[dbo].[Employees] AS [Employees]
INNER JOIN
	[dbo].[Employees] AS [Managers]
	ON [Managers].[EmployeeID] = [Employees].[ManagerID]
INNER JOIN
	[dbo].[Departments] AS [Departments]
	ON [Departments].[DepartmentID] = [Employees].[DepartmentID]
ORDER BY
	[Employees].[EmployeeID] ASC