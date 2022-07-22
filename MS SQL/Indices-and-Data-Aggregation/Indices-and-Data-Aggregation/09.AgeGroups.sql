SELECT
	[Age Group],
	COUNT(*) AS [Wizard Count]
FROM (
	SELECT
		CASE
			WHEN [WizzardDeposits].[Age] BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN [WizzardDeposits].[Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [WizzardDeposits].[Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [WizzardDeposits].[Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [WizzardDeposits].[Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [WizzardDeposits].[Age] BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN [WizzardDeposits].[Age] >= 61 THEN '[61+]'
		END AS [Age Group]
    FROM
		[dbo].[WizzardDeposits] AS [WizzardDeposits]) AS [Ranking]
GROUP BY
	[Age Group]