SELECT TOP(30) [CountryName], [Population]
FROM [dbo].[Countries]
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC, CountryName ASC