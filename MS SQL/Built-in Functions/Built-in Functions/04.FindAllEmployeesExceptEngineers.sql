SELECT [FirstName], [LastName]
FROM [dbo].[Employees]
WHERE CHARINDEX('engineer', JobTitle) = 0