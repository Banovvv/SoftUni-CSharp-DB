SELECT
	[ContinentCode],
	[CurrencyCode],
	[Currency Count] AS [Currency Usage]
FROM (
    SELECT
		   [ContinentCode],
           [CurrencyCode],
           [Currency Count],
           DENSE_RANK() OVER (
			 PARTITION BY
				 [ContinentCode]
			 ORDER BY
				 [Currency Count] DESC) AS [Currency Rank]
    FROM (SELECT
				 [Country].[ContinentCode],
                 [Country].[CurrencyCode],
                 COUNT(*) AS [Currency Count]
              FROM [dbo].[Countries] AS [Country]
              GROUP BY
				 [ContinentCode],
				 [CurrencyCode]) AS [Currency Count]
    WHERE
		[Currency Count] > 1) AS [Currency Ranking]
WHERE
	[Currency Rank] = 1
ORDER BY
	[ContinentCode] ASC