CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@balance decimal(18, 4)) AS
SELECT
	[dbo].[AccountHolders].[FirstName],
	[dbo].[AccountHolders].[LastName]
FROM
	[dbo].[AccountHolders]
JOIN
	[dbo].[Accounts]
	ON [dbo].[AccountHolders].[Id] = [dbo].[Accounts].[AccountHolderId]
GROUP BY
	[dbo].[AccountHolders].[FirstName], [dbo].[AccountHolders].[LastName]
HAVING
	SUM([dbo].[Accounts].[Balance]) > @balance
ORDER BY
	[dbo].[AccountHolders].[FirstName], [dbo].[AccountHolders].[LastName]

GO

EXEC usp_GetHoldersWithBalanceHigherThan 15000