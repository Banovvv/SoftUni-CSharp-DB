SELECT
	[FirstName],
	[LastName]
FROM
	[dbo].[Employees]
WHERE
	FirstName LIKE 'Sa%'





SELECT
	[FirstName],
	[LastName]
FROM
	[dbo].[Employees]
WHERE
	LEFT(FirstName, 2) = 'Sa'