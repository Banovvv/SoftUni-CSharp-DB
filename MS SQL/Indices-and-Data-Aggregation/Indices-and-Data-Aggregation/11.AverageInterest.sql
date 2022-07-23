SELECT
	[WizzardDeposits].[DepositGroup],
	[WizzardDeposits].[IsDepositExpired],
	AVG([WizzardDeposits].[DepositInterest]) AS [AverageInterest]
FROM
	[dbo].[WizzardDeposits] AS [WizzardDeposits]
WHERE
	[WizzardDeposits].[DepositStartDate] > '01-01-1985'
GROUP BY
	[WizzardDeposits].[DepositGroup],
	[WizzardDeposits].[IsDepositExpired]
ORDER BY
	[WizzardDeposits].[DepositGroup] DESC,
	[WizzardDeposits].[IsDepositExpired]