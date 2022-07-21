SELECT
	[dbo].[WizzardDeposits].[DepositGroup],
	[dbo].[WizzardDeposits].[MagicWandCreator],
	MIN([dbo].[WizzardDeposits].[DepositCharge]) AS [MinDepositCharge]
FROM
	[dbo].[WizzardDeposits]
GROUP BY
	[dbo].[WizzardDeposits].[DepositGroup],
	[dbo].[WizzardDeposits].[MagicWandCreator]
ORDER BY
	[MagicWandCreator] ASC,
	[DepositGroup] ASC