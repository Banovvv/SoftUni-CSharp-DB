SELECT
	[dbo].[WizzardDeposits].[DepositGroup],
	SUM([dbo].[WizzardDeposits].[DepositAmount]) AS [TotalSum]
FROM
	[dbo].[WizzardDeposits]
GROUP BY
	[dbo].[WizzardDeposits].[DepositGroup]
