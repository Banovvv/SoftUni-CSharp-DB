SELECT
	[dbo].[Employees].[EmployeeID],
	[dbo].[Employees].[FirstName],
	CASE
		WHEN YEAR([dbo].[Projects].[StartDate]) < 2005 THEN [dbo].[Projects].[Name]
		WHEN YEAR([dbo].[Projects].[StartDate]) = 2005 THEN 'NULL'
		WHEN YEAR([dbo].[Projects].[StartDate]) > 2005 THEN 'NULL'
	END AS [Project Name]
FROM
	[dbo].[Employees]
INNER JOIN
	[dbo].[EmployeesProjects]
	ON [dbo].[EmployeesProjects].[EmployeeID] = [dbo].[Employees].[EmployeeID]
INNER JOIN
	[dbo].[Projects]
	ON [dbo].[EmployeesProjects].[ProjectID] = [dbo].[Projects].[ProjectID]
WHERE
	[dbo].[Employees].[EmployeeID] = 24