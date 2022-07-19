SELECT
	[dbo].[Countries].[CountryCode],
	[dbo].[Mountains].[MountainRange],
	[dbo].[Peaks].[PeakName],
	[dbo].[Peaks].[Elevation]
FROM
	[dbo].[Countries]
INNER JOIN
	[dbo].[MountainsCountries]
	ON [dbo].[MountainsCountries].[CountryCode] = [dbo].[Countries].[CountryCode]
INNER JOIN
	[dbo].[Mountains]
	ON [dbo].[Mountains].[Id] = [dbo].[MountainsCountries].[MountainId]
INNER JOIN
	[dbo].[Peaks]
	ON [dbo].[Peaks].[MountainId] = [dbo].[Mountains].[Id]
WHERE
	[dbo].[Countries].[CountryName] = 'Bulgaria' AND
	[dbo].[Peaks].[Elevation] > 2835
ORDER BY
	[dbo].[Peaks].[Elevation] DESC