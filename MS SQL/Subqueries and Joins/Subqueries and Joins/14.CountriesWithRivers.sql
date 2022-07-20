SELECT TOP(5)
	[dbo].[Countries].[CountryName],
	[dbo].[Rivers].[RiverName]
FROM
	[dbo].[Countries]
FULL JOIN
	[dbo].[CountriesRivers]
	ON [dbo].[CountriesRivers].[CountryCode] = [dbo].[Countries].CountryCode
FULL JOIN
	[dbo].[Rivers]
	ON [dbo].[Rivers].[Id] = [dbo].[CountriesRivers].[RiverId]
INNER JOIN
	[dbo].[Continents]
	ON [dbo].[Continents].[ContinentCode] = [dbo].[Countries].[ContinentCode]
WHERE
	[dbo].[Continents].[ContinentName] = 'Africa'
ORDER BY
	[dbo].[Countries].[CountryName] ASC