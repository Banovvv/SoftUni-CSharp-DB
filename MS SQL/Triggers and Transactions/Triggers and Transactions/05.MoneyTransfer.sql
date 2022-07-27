CREATE PROC
	usp_TransferMoney(@SenderId int, @ReceiverId int, @Amount money) AS
BEGIN
    BEGIN TRANSACTION
        IF @Amount > 0
            BEGIN
                EXEC [dbo].[usp_TransferMoney] @SenderId, @Amount;
                EXEC [dbo].[usp_DepositMoney] @ReceiverId, @Amount;
            END
    COMMIT
END
GO

EXEC
	usp_TransferMoney 15, 12, 10000

SELECT * FROM [dbo].[Logs]
SELECT * FROM [dbo].[NotificationEmails]