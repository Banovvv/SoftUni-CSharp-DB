SELECT [Name],
	CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] > 3 AND [Duration] <= 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		WHEN [Duration] IS NULL THEN 'Extra Long'
	END AS [Duration In Words]
FROM [dbo].[Games]
ORDER BY [Name] ASC, [Duration In Words] ASC, [Part of the Day] ASC