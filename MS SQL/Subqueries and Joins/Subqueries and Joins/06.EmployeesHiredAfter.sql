SELECT
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName],
	[dbo].[Employees].[HireDate],
	[dbo].[Departments].[Name]
FROM
	[dbo].[Employees]
INNER JOIN
	[dbo].[Departments]
	ON [dbo].[Departments].[DepartmentID] = [dbo].[Employees].[DepartmentID]
WHERE
	[dbo].[Employees].[HireDate] >= '1999-1-1' AND
	[dbo].[Departments].[Name] in ('Sales', 'Finance')
ORDER BY
	[dbo].[Employees].[HireDate] ASC