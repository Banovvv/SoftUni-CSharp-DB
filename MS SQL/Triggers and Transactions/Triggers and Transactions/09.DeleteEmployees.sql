CREATE TABLE [dbo].[DeletedEmployees]
(
    EmployeeId INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50),
    JobTitle NVARCHAR(50) NOT NULL,
    DepartmentId INT NOT NULL,
    Salary MONEY NOT NULL
)

GO

CREATE TRIGGER
	tr_InsertEmployeesOnDelete
    on [dbo].[Employees]
    AFTER DELETE AS
    BEGIN
        INSERT INTO
			[dbo].[DeletedEmployees]
        SELECT
			[Deleted].[FirstName],
			[Deleted].[LastName],
			[Deleted].[MiddleName],
			[Deleted].[JobTitle],
			[Deleted].[DepartmentID],
			[Deleted].[Salary]
        FROM
			[Deleted]
    END
GO

DELETE
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[EmployeeID] = 293

SELECT * FROM [dbo].[DeletedEmployees]