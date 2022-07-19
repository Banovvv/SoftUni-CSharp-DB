CREATE VIEW
	[V_EmployeesSalaries] AS
SELECT
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName],
	[dbo].[Employees].[Salary]
FROM
	[dbo].[Employees]