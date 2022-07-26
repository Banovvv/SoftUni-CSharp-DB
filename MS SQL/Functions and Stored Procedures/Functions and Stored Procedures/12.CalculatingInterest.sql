CREATE PROCEDURE
	usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT) AS
SELECT
	[dbo].[AccountHolders].[Id],
	[dbo].[AccountHolders].[FirstName],
	[dbo].[AccountHolders].[LastName],
	[dbo].[Accounts].[Balance],
    dbo.ufn_CalculateFutureValue([dbo].[Accounts].[Balance], @interestRate, 5)
FROM
	[dbo].[AccountHolders]
JOIN
	[dbo].[Accounts]
	ON [dbo].[AccountHolders].[Id] = [dbo].[Accounts].AccountHolderId
WHERE
	[dbo].[Accounts].[Id] = @accountId

GO

EXEC
	usp_CalculateFutureValueForAccount 1, 0.1