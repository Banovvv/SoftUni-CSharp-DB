SELECT [Username], [IPAddress]
FROM [dbo].[Users]
WHERE [IPAddress] LIKE '___.1%.%.___'
ORDER BY [Username] ASC