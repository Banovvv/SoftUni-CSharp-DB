SELECT
	SUBSTRING([Email], 1, CHARINDEX('@', [Email], 1) - 1) AS [Username],
	SUBSTRING([Email], CHARINDEX('@', [Email], 1) + 1, (LEN([Email])-CHARINDEX('@', [Email], 1))) AS [Email Provider]
FROM [dbo].[Users]
ORDER BY [Email Provider] ASC, [Username] ASC