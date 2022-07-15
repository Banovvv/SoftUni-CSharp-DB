SELECT [dbo].[Mountains].[MountainRange], [PeakName], [Elevation]
FROM [dbo].[Peaks]
INNER JOIN [dbo].[Mountains] ON ([dbo].[Mountains].[Id] = [dbo].[Peaks].[MountainId])
WHERE [dbo].[Mountains].[MountainRange] = 'Rila'
ORDER BY [Elevation] DESC