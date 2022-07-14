SELECT [CountryName], [CountryCode], 
CASE
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	WHEN CurrencyCode <> 'EUR' THEN 'Not Euro'
END AS 'Currency'
FROM [dbo].[Countries]
ORDER BY CountryName ASC