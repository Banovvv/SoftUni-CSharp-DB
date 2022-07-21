SELECT TOP(2)
	[dbo].[WizzardDeposits].[DepositGroup]	
FROM
	[dbo].[WizzardDeposits]
GROUP BY
	[dbo].[WizzardDeposits].[DepositGroup]
ORDER BY
	AVG([dbo].[WizzardDeposits].[MagicWandSize]) ASC