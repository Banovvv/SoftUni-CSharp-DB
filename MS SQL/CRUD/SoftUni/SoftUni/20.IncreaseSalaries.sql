UPDATE
	[dbo].[Employees]
SET
	[dbo].[Employees].[Salary] = [dbo].[Employees].[Salary] * 1.12
WHERE
	[dbo].[Employees].[DepartmentID] in (1, 2, 4)





SELECT
	[Salary]
FROM
	[dbo].[Employees]