SELECT TOP(5)
	[dbo].[Employees].[EmployeeID],
	[dbo].[Employees].[FirstName],
	[dbo].[Projects].[Name]
FROM
	[dbo].[Employees]
INNER JOIN
	[dbo].[EmployeesProjects]
	ON [dbo].[EmployeesProjects].[EmployeeID] = [dbo].[Employees].[EmployeeID]
INNER JOIN
	[dbo].[Projects]
	ON [dbo].[EmployeesProjects].[ProjectID] = [dbo].[Projects].[ProjectID]
WHERE
	[dbo].[Projects].[StartDate] >= '2002-08-13' AND
	[dbo].[Projects].EndDate IS NULL
ORDER BY
	[dbo].[Employees].[EmployeeID] ASC