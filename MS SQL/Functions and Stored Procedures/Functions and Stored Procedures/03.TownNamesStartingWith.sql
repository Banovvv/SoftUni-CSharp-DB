CREATE PROCEDURE usp_GetTownsStartingWith(@string VARCHAR(15))
AS
SELECT
	[dbo].[Towns].[Name] AS [Town]
FROM
	[dbo].[Towns]
WHERE
	[dbo].[Towns].[Name] LIKE @string + '%'

GO

EXEC usp_GetTownsStartingWith 'b'