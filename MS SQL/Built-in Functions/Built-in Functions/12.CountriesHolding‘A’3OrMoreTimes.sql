SELECT [CountryName], [IsoCode]
FROM [dbo].[Countries]
WHERE (LEN([CountryName]) - LEN(REPLACE(LOWER([CountryName]), 'a', ''))) = 3
ORDER BY [IsoCode] ASC