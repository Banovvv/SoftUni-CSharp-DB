CREATE PROCEDURE
	[usp_EmployeesBySalaryLevel](@salary VARCHAR(10)) AS
SELECT
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName]
FROM
	[dbo].[Employees]
WHERE
	[dbo].[ufn_GetSalaryLevel]([dbo].[Employees].[Salary]) = @Salary

GO

EXEC [usp_EmployeesBySalaryLevel] 'High'