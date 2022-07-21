SELECT TOP(5)
	[Countries].[CountryName],
	Max([Peaks].[Elevation]) AS [Highest Peak Elevation],
	MAX([Rivers].[Length]) AS [Longest River Length]
FROM
	[dbo].[Countries] AS [Countries]
LEFT OUTER JOIN
	[dbo].[CountriesRivers] AS [CountriesRivers]
	ON [Countries].[CountryCode] = [CountriesRivers].[CountryCode]
LEFT OUTER JOIN
	[dbo].[Rivers] AS [Rivers]
	ON [CountriesRivers].[RiverId] = [Rivers].[Id]
LEFT OUTER JOIN
	[dbo].[MountainsCountries] AS [MountainsCountries]
    ON [Countries].[CountryCode] = [MountainsCountries].[CountryCode]
LEFT OUTER JOIN
	[dbo].[Mountains] AS [Mountains]
	ON [Mountains].[Id] = [MountainsCountries].[MountainId]
LEFT OUTER JOIN
	[dbo].[Peaks] AS [Peaks]
	ON [Peaks].[MountainId] = [Mountains].[Id]
GROUP BY
	[Countries].[CountryName]
ORDER BY
	[Highest Peak Elevation] DESC,
	[Longest River Length] DESC,
	[Countries].[CountryName] ASC