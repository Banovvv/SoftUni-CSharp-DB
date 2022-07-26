CREATE PROCEDURE usp_GetEmployeesWithSalaryAbove35000
AS
SELECT
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName]
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].Salary > 35000

GO

EXEC usp_GetEmployeesWithSalaryAbove35000