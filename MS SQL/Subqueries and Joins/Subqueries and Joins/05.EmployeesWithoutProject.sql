SELECT TOP(3)
	[dbo].[Employees].[EmployeeID],
	[dbo].[Employees].[FirstName]
FROM
	[dbo].[Employees]
LEFT JOIN
	[dbo].[EmployeesProjects]
	ON [dbo].[EmployeesProjects].[EmployeeID] = [dbo].[Employees].[EmployeeID]
WHERE
	[dbo].[EmployeesProjects].[ProjectID] IS NULL
ORDER BY
	[dbo].[Employees].[EmployeeID] ASC