SELECT [FirstName]
FROM [dbo].[Employees]
WHERE DepartmentID in (3, 10)
AND YEAR(HireDate) > 1995
AND YEAR(HireDate) < 2005