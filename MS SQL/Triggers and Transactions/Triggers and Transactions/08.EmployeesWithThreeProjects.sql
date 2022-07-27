CREATE PROC
	usp_AssignProject(@emloyeeId int, @projectID int) AS
BEGIN
    BEGIN TRANSACTION
        IF (SELECT COUNT(*) FROM [dbo].[EmployeesProjects] WHERE [dbo].[EmployeesProjects].[EmployeeID] = @emloyeeId) >= 3
            BEGIN
                ROLLBACK
                RAISERROR ('The employee has too many projects!', 16, 1)
            END
        INSERT INTO
			[dbo].[EmployeesProjects]
        VALUES
			(@emloyeeId, @projectID);
    COMMIT
END