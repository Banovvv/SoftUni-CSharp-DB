SELECT [TownID], [Name]
FROM [dbo].[Towns]
WHERE [Name] LIKE ('M%')
OR [Name] LIKE ('K%')
OR [Name] LIKE ('B%')
OR [Name] LIKE ('E%')
ORDER BY [Name] ASC