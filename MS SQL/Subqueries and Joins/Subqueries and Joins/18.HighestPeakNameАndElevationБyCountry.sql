SELECT
	[Country],
    IIF([PeakName] IS NULL, '(no highest peak)', PeakName) AS [Highest Peak Name],
    IIF([Elevation] IS NULL, 0, Elevation) AS [Highest Peak Elevation],
    IIF([MountainRange] IS NULL, '(no mountain)', MountainRange) AS [Mountain]
FROM
	(SELECT *,
		DENSE_RANK() OVER (PARTITION BY [Country] ORDER BY [Elevation] DESC ) AS [Peak Rank]
          FROM 
              (SELECT CountryName AS [Country],
                     [Peaks].[PeakName],
                     [Peaks].[Elevation],
                     [Mountains].[MountainRange]
               FROM [Countries]
                        LEFT OUTER JOIN
							[dbo].[MountainsCountries] AS [MountainsCountries]
                             ON Countries.CountryCode = [MountainsCountries].[CountryCode]
                        LEFT OUTER JOIN
							[dbo].[Mountains] AS [Mountains]
                            ON [MountainsCountries].[MountainId] = [Mountains].[Id]
                        LEFT OUTER JOIN
							[dbo].[Peaks] AS [Peaks]
                            ON [Mountains].[Id] = [Peaks].[MountainId]) AS [Full Info Query]) AS PeakRankings
WHERE [Peak Rank] = 1
ORDER BY [Country], [Highest Peak Name]