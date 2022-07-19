SELECT
	CONCAT([dbo].[Employees].[FirstName], '.', [dbo].[Employees].[LastName], '@softuni.bg') AS 'Full Email Address'
FROM
	[dbo].[Employees] 