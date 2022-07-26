CREATE FUNCTION
	ufn_CashInUsersGames(@gameName NVARCHAR(MAX))
	RETURNS TABLE AS
RETURN
	SELECT
		SUM(Cash) AS [SumCash]
    FROM (
		SELECT
			[dbo].[Games].[Name],
            [dbo].[UsersGames].[Cash],
            ROW_NUMBER()
				OVER ( PARTITION BY [dbo].[Games].[Name]
						ORDER BY [dbo].[UsersGames].Cash DESC ) AS [RowNum]
        FROM
			[dbo].[Games]
        JOIN
			[dbo].[UsersGames]
			ON [dbo].[Games].Id = [dbo].[UsersGames].[GameId]
        WHERE
			[dbo].[Games].[Name] = @gameName) AS Row
    WHERE
		[RowNum] % 2 != 0


SELECT * FROM
	dbo.ufn_CashInUsersGames('Love in a mist')