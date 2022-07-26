CREATE PROCEDURE
	usp_DeleteEmployeesFromDepartment(@departmentId int) AS
DELETE
    FROM
		[dbo].[EmployeesProjects]
    WHERE
		[dbo].[EmployeesProjects].[EmployeeID] IN (SELECT [dbo].[Employees].[EmployeeID]
                             FROM
								[dbo].[Employees]
                             WHERE
								[dbo].[Employees].[DepartmentID] = @departmentId)

UPDATE
	[dbo].[Employees]
SET
	[dbo].[Employees].[ManagerID] = NULL
WHERE
	[dbo].[Employees].[ManagerID] IN (SELECT EmployeeID
                            FROM
								[dbo].[Employees]
                            WHERE
								[dbo].[Employees].[DepartmentID] = @departmentId)
    ALTER TABLE
		[dbo].[Departments]
    ALTER COLUMN
		[ManagerID] int

UPDATE
	[dbo].[Departments]
SET
	[dbo].[Departments].[ManagerID] = NULL
WHERE
	[dbo].[Departments].[ManagerID] IN (SELECT EmployeeID
                            FROM
								[dbo].[Employees]
                            WHERE
								[dbo].[Employees].[DepartmentID] = @departmentId)

DELETE
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[DepartmentID] = @departmentId

DELETE
FROM
	[dbo].[Departments]
WHERE
	[dbo].[Departments].[DepartmentID] = @departmentId

SELECT
	COUNT(*)
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[DepartmentID] = @departmentId

GO

usp_DeleteEmployeesFromDepartment 5