CREATE TABLE [dbo].[Teachers]
(
    TeacherID INT IDENTITY (101,1) PRIMARY KEY,
    [Name] NVARCHAR(20) NOT NULL,
    ManagerID INT FOREIGN KEY REFERENCES Teachers (TeacherID)
)

INSERT INTO [dbo].[Teachers]
([Name], [ManagerID])

VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101);