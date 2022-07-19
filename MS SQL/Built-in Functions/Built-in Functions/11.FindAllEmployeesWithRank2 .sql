SELECT * FROM
	(SELECT
		[EmployeeID],
		[FirstName],
		[LastName],
		[Salary],
		DENSE_RANK() OVER(
			PARTITION BY
				[Salary]
			ORDER BY
				[EmployeeID] ASC)
		AS RANK
	FROM
		[dbo].[Employees]
	WHERE
		[Salary] > 10000 AND
		[Salary] < 50000)
	AS SubQuery
WHERE
	RANK = 2
ORDER BY
	[Salary] DESC