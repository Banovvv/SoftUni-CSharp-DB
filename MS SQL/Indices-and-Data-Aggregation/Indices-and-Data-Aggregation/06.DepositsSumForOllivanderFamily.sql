SELECT
	[dbo].[WizzardDeposits].[DepositGroup],
	SUM([dbo].[WizzardDeposits].[DepositAmount]) AS [TotalSum]
FROM
	[dbo].[WizzardDeposits]
WHERE
	[dbo].[WizzardDeposits].[MagicWandCreator] = 'Ollivander family'
GROUP BY
	[dbo].[WizzardDeposits].[DepositGroup]
