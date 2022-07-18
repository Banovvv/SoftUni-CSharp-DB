SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd')
FROM [dbo].[Games]
WHERE YEAR([Start]) in (2011, 2012)
ORDER BY [Start] ASC, [Name] ASC