CREATE VIEW
	[V_EmployeesHiredAfter2000] AS
SELECT
	[FirstName],
	[LastName]
FROM
	[dbo].[Employees]
WHERE
	YEAR(HireDate) > 2000