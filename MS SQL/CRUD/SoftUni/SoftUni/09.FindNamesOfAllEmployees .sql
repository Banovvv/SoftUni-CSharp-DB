SELECT
	CONCAT_WS(' ', [dbo].[Employees].[FirstName], [dbo].[Employees].[MiddleName], [dbo].[Employees].[LastName]) AS 'Full Name'
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[Salary] in (12500, 14000, 23600, 25000)