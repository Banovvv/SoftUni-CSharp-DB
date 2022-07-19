SELECT
	[dbo].[Countries].[CountryName],
	[dbo].[Countries].[CountryCode], 
	CASE
		WHEN [dbo].[Countries].[CurrencyCode] = 'EUR' THEN 'Euro'
		WHEN [dbo].[Countries].[CurrencyCode] <> 'EUR' THEN 'Not Euro'
	END AS 'Currency'
FROM
	[dbo].[Countries]
ORDER BY
	[dbo].[Countries].[CountryName] ASC