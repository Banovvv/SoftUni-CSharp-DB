SELECT
	LEFT([WizzardDeposits].[FirstName], 1)
FROM
	[dbo].[WizzardDeposits] AS [WizzardDeposits]
WHERE
	[WizzardDeposits].[DepositGroup] = 'Troll Chest'
GROUP BY
	LEFT([WizzardDeposits].[FirstName], 1)
ORDER BY
	LEFT([WizzardDeposits].[FirstName], 1) ASC