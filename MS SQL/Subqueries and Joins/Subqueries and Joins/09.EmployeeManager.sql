SELECT
	[Employees].[EmployeeID],
	[Employees].[FirstName] AS [FirstName],
	[Employees].[ManagerID],
	[Managers].[FirstName] AS [ManagerName]
FROM
	[dbo].[Employees] [Employees],
	[dbo].[Employees] [Managers]
WHERE
	[Employees].[ManagerID] = [Managers].[EmployeeID] AND
	[Employees].[ManagerID] in (3, 7)
ORDER BY
	[Employees].[EmployeeID] ASC