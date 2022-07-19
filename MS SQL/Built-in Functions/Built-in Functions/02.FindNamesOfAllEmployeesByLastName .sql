SELECT
	[FirstName],
	[LastName]
FROM
	[dbo].[Employees]
WHERE
	CHARINDEX('ei', LastName) > 0