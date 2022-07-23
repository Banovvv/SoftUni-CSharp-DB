SELECT
	SUM([Difference]) AS [SumDifference]
FROM (
	SELECT
		[WizzardDeposits].[FirstName] AS [HostWizard],
        [WizzardDeposits].[DepositAmount] AS [HostWizardDeposit],
        LEAD([WizzardDeposits].[FirstName]) OVER (ORDER BY [WizzardDeposits].[Id]) AS [GuestWizard],
        LEAD([WizzardDeposits].[DepositAmount]) OVER (ORDER BY [WizzardDeposits].[Id]) AS [GuestWizardDeposit],
        [WizzardDeposits].[DepositAmount] - LEAD([WizzardDeposits].[DepositAmount]) OVER (ORDER BY [WizzardDeposits].[Id]) AS [Difference]
    FROM
		[dbo].[WizzardDeposits] AS [WizzardDeposits]) AS [DifferenceQuery]





SELECT
	SUM([Difference]) AS [SumDifference]
FROM (
	SELECT
		[WizzardDeposits].[DepositAmount] - LEAD([WizzardDeposits].[DepositAmount])
		OVER (ORDER BY [WizzardDeposits].[Id]) AS [Difference]
    FROM
		[dbo].[WizzardDeposits] AS [WizzardDeposits]) AS [DifferenceQuery]