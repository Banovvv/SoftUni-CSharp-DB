CREATE TABLE [dbo].[Logs]
(
	LogId INT IDENTITY(1, 1) PRIMARY KEY,
	AccountId INT NOT NULL
		FOREIGN KEY REFERENCES [dbo].[Accounts](Id),
	OldSum Money NOT NULL,
	NewSum Money NOT NULL
)

CREATE TRIGGER
	tr_AddToLogsOnAccountUpdate
ON
	[dbo].[Accounts]
FOR UPDATE AS
INSERT INTO
	[dbo].[Logs]
	([AccountId], [OldSum], [NewSum])
SELECT
	[Inserted].[Id],
	[Deleted].[Balance],
	[Inserted].[Balance]
FROM
	[Inserted]
JOIN
	[Deleted]
	ON [Inserted].[Id] = [Deleted].[Id]
WHERE
	[Inserted].[Balance] != [Deleted].[Balance]

GO