SELECT CONCAT_WS(' ', [FirstName], [MiddleName], [LastName]) AS 'Full Name'
FROM [dbo].[Employees]
WHERE Salary in (12500, 14000, 23600, 25000)