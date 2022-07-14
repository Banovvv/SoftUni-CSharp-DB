UPDATE [dbo].[Employees]
SET Salary = Salary * 1.12
WHERE DepartmentID in (1, 2, 4)

SELECT [Salary] FROM [dbo].[Employees]