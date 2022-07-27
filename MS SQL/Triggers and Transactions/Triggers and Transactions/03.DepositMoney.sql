CREATE PROC
	usp_DepositMoney(@AccountId int, @MoneyAmount money) AS
BEGIN TRANSACTION
	IF (@MoneyAmount < 0)
		THROW 50001, 'Amount should be positive', 1;
	IF (SELECT COUNT(*)  FROM [dbo].[Accounts]  WHERE [dbo].[Accounts].[Id] = @AccountId) < 1
	    THROW 50002,'Invalid AccountID', 1;
	
	UPDATE
		[dbo].[Accounts]
	SET
		[dbo].[Accounts].[Balance] += @MoneyAmount
	WHERE
		@AccountId = [dbo].[Accounts].[Id];
COMMIT

GO

EXEC usp_DepositMoney 1, 10

SELECT * FROM [dbo].[Logs];

SELECT * FROM [dbo].[NotificationEmails];