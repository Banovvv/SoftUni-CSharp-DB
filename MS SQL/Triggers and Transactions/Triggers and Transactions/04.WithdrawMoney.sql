CREATE PROC
	usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY) AS
BEGIN
	BEGIN TRAN
		IF (@MoneyAmount > 0)
		BEGIN
			UPDATE
				[dbo].[Accounts]
			SET
				[dbo].[Accounts].[Balance] -= @MoneyAmount
			WHERE
				[dbo].[Accounts].[Id] = @AccountId

			IF @@ROWCOUNT != 1
			BEGIN
				ROLLBACK
				RAISERROR('Invalid account!', 16, 1)
				RETURN
			END
		END
	COMMIT
END

GO

exec usp_WithdrawMoney 1,10

SELECT * FROM [dbo].[Logs]
SELECT * FROM [dbo].[NotificationEmails]