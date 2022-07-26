CREATE PROCEDURE
	usp_GetEmployeesWithSalaryAboveNumber(@number DECIMAL(18, 4)) AS
SELECT
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName]
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].Salary > @number

GO

EXEC usp_GetEmployeesWithSalaryAboveNumber 48100