CREATE TABLE [dbo].[NotificationEmails]
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Recipient INT NOT NULL
		REFERENCES [dbo].[Accounts](Id),
	[Subject] NVARCHAR(100) NOT NULL,
	Body NVARCHAR(500) NOT NULL
)

CREATE OR ALTER TRIGGER
	tr_AddToNotificationEmailOnLogsUpdate
ON
	[dbo].[Logs]
FOR INSERT AS
INSERT INTO
	[dbo].[NotificationEmails]
	([Recipient], [Subject], [Body])
SELECT
	[Inserted].[AccountID],
    'Balance change for account: ' + CAST([Inserted].[AccountID] AS NVARCHAR(20)),
    'On ' + CONVERT(nvarchar(20), GETDATE(), 100) + ' your balance was changed from ' +
    CAST([Inserted].[OldSum] AS nvarchar(20)) + ' to ' + CAST([Inserted].[NewSum] AS NVARCHAR(20)) + '.'
FROM
	[Inserted]

GO

EXEC
	usp_TransferFunds 12, 15,1000

SELECT * FROM
	[dbo].[Logs]

SELECT * FROM
	[dbo].[NotificationEmails]