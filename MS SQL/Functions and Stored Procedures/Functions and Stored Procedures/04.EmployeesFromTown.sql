CREATE PROCEDURE
	usp_GetEmployeesFromTown(@town NVARCHAR(50)) AS
SELECT
	[dbo].[Employees].[FirstName],
	[dbo].[Employees].[LastName]
FROM
	[dbo].[Employees]
INNER JOIN
	[dbo].[Addresses]
	ON [dbo].[Addresses].[AddressID] = [dbo].[Employees].[AddressID]
INNER JOIN
	[dbo].[Towns]
	ON [dbo].[Towns].[TownID] = [dbo].[Addresses].[TownID]
WHERE
	[dbo].[Towns].[Name] = @town

GO

EXEC usp_GetEmployeesFromTown 'Sofia'