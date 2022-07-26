SELECT
	COUNT([dbo].[Employees].[Salary]) AS [EmployeeSalaryCountWithNoManager]
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[ManagerID] IS NULL