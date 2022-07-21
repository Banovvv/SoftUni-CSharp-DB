SELECT
	[dbo].[WizzardDeposits].[DepositGroup],
	MAX([dbo].[WizzardDeposits].[MagicWandSize]) AS [Longest Magic Wand]
FROM
	[dbo].[WizzardDeposits]
GROUP BY
	[dbo].[WizzardDeposits].[DepositGroup]