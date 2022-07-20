SELECT
	COUNT(*) - COUNT([MountainsCountries].[CountryCode]) AS [Count]
FROM
	[dbo].[Countries] AS [Countries]
LEFT JOIN
	[dbo].[MountainsCountries] AS [MountainsCountries]
    ON [Countries].CountryCode = [MountainsCountries].[CountryCode]