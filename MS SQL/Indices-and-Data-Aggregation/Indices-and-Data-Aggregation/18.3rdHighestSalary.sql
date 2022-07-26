SELECT
	[HighestSalaryQuery].[DepartmentID],
	[HighestSalaryQuery].[MaxSalary]
FROM (
	SELECT
		[dbo].[Employees].[DepartmentID],
        MAX([dbo].[Employees].[Salary]) AS [MaxSalary],
        DENSE_RANK() OVER (
			PARTITION BY
				[dbo].[Employees].[DepartmentID]
			ORDER BY
				[dbo].[Employees].[Salary] DESC) AS [Rank]
    FROM
		[dbo].[Employees]
    GROUP BY
		[dbo].[Employees].[DepartmentID],
		[dbo].[Employees].Salary) AS [HighestSalaryQuery]
WHERE
	[HighestSalaryQuery].[Rank] = 3