CREATE VIEW
	[V_EmployeeNameJobTitle] AS
SELECT
	CONCAT([dbo].[Employees].[FirstName], ISNULL(' ' + [dbo].[Employees].[MiddleName], ''), ' ', [dbo].[Employees].[LastName], ' ') AS 'Full Name',
	[dbo].[Employees].[JobTitle]
FROM [dbo].[Employees]