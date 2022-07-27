DECLARE @userName NVARCHAR(max) = 'Stamat'
DECLARE @gameName NVARCHAR(max) = 'Safflower'
DECLARE @userID INT = (SELECT [dbo].[Users].[Id] 
                       FROM [dbo].[Users] 
                       WHERE [dbo].[Users].[Username] = @userName)
DECLARE @gameID INT = (SELECT [dbo].[Games].[Id] 
                       FROM [dbo].[Games]
                       WHERE [dbo].[Games].[Name] = @gameName)
DECLARE @userMoney MONEY = (SELECT [dbo].[UsersGames].[Cash] 
                            FROM [dbo].[UsersGames]
                            WHERE [dbo].[UsersGames].[UserId] = @userID AND [dbo].[UsersGames].[GameId] = @gameID)
DECLARE @itemsTotalPrice MONEY
DECLARE @userGameID int = (SELECT [dbo].[UsersGames].[Id] 
                           FROM [dbo].[UsersGames] 
                           WHERE [dbo].[UsersGames].[UserId] = @userID AND [dbo].[UsersGames].[GameId] = @gameID)
 
BEGIN TRANSACTION
    SET @itemsTotalPrice = (SELECT SUM([dbo].[Items].[Price]) 
							FROM [dbo].[Items]
							WHERE [dbo].[Items].[MinLevel] BETWEEN 11 AND 12)
 
    IF(@userMoney - @itemsTotalPrice >= 0)
		BEGIN
		    INSERT INTO [dbo].[UserGameItems]
		    SELECT [dbo].[Items].[Id], @userGameID FROM [dbo].[Items]
		    WHERE [dbo].[Items].[Id] IN (SELECT [dbo].[Items].[Id]
										 FROM [dbo].[Items]
										 WHERE [dbo].[Items].[MinLevel] BETWEEN 11 AND 12) 
		    UPDATE [dbo].[UsersGames]
		    SET [dbo].[UsersGames].[Cash] -= @itemsTotalPrice
		    WHERE [dbo].[UsersGames].[GameId] = @gameID AND [dbo].[UsersGames].[UserId] = @userID
			COMMIT
		END
    ELSE
		BEGIN
		    ROLLBACK
		END
 
SET @userMoney = (SELECT [dbo].[UsersGames].[Cash] 
                  FROM [dbo].[UsersGames] 
                  WHERE [dbo].[UsersGames].[GameId] = @gameID AND [dbo].[UsersGames].[UserId] = @userID)
BEGIN TRANSACTION
    SET @itemsTotalPrice = (SELECT SUM([dbo].[Items].[Price]) 
							FROM [dbo].[Items]
							WHERE [dbo].[Items].[MinLevel] BETWEEN 19 AND 21) 
    IF(@userMoney - @itemsTotalPrice >= 0)
		BEGIN
		    INSERT INTO [dbo].[UserGameItems]
		    SELECT [dbo].[Items].[Id], @userGameID
			FROM [dbo].[Items]
		    WHERE [dbo].[Items].[Id] IN (SELECT [dbo].[Items].[Id]
										 FROM [dbo].[Items]
										 WHERE [dbo].[Items].[MinLevel] BETWEEN 19 AND 21)  
		    UPDATE [dbo].[UsersGames]
		    SET [dbo].[UsersGames].[Cash] -= @itemsTotalPrice
		    WHERE [dbo].[UsersGames].[GameId] = @gameID AND [dbo].[UsersGames].[UserId] = @userID
		    COMMIT
		END
    ELSE
		BEGIN
		    ROLLBACK
		END
 
SELECT
	[dbo].[Items].[Name] AS [Item Name]
FROM
	[dbo].[Items]
WHERE
	[dbo].[Items].[Id] IN (SELECT [dbo].[UserGameItems].[ItemId] 
						   FROM [dbo].[UserGameItems]
						   WHERE [dbo].[UserGameItems].[UserGameId] = @userGameID)
ORDER BY
	[Item Name] ASC