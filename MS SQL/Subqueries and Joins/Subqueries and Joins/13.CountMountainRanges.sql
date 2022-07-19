SELECT
	[dbo].[Countries].[CountryCode],
	COUNT([dbo].[Mountains].[MountainRange])
FROM
	[dbo].[Countries]
INNER JOIN
	[dbo].[MountainsCountries]
	ON [dbo].[MountainsCountries].[CountryCode] = [dbo].[Countries].[CountryCode]
INNER JOIN
	[dbo].[Mountains]
	ON [dbo].[Mountains].[Id] = [dbo].[MountainsCountries].[MountainId]
WHERE
	[dbo].[Countries].[CountryName] in ('United States', 'Russia', 'Bulgaria')
GROUP BY
	[dbo].[Countries].[CountryCode]