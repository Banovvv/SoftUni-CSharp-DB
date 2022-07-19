SELECT TOP(10) *
FROM
	[dbo].[Projects]
WHERE
	[dbo].[Projects].[StartDate] IS NOT NULL
ORDER BY
	[dbo].[Projects].[StartDate] ASC,
	[dbo].[Projects].[Name] ASC