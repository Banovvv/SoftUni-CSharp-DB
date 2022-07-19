SELECT
	[Name]
FROM
	[dbo].[Towns]
WHERE
	LEN([Name]) in (5, 6)
ORDER BY
	[Name] ASC