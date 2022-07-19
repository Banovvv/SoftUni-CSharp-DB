SELECT TOP(30)
	[dbo].[Countries].[CountryName],
	[dbo].[Countries].[Population]
FROM
	[dbo].[Countries]
WHERE
	[dbo].[Countries].[ContinentCode] = 'EU'
ORDER BY
	[dbo].[Countries].[Population] DESC,
	[dbo].[Countries].[CountryName] ASC