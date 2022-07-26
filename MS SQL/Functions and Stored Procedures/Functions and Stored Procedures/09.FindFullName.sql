CREATE PROCEDURE
	usp_GetHoldersFullName	AS
SELECT
	[dbo].[AccountHolders].[FirstName] + ' ' + [dbo].[AccountHolders].[LastName] AS [FullName]
FROM
	[dbo].[AccountHolders]

GO

EXEC usp_GetHoldersFullName