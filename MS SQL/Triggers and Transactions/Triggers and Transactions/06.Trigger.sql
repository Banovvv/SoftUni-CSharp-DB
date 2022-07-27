SELECT * FROM [dbo].[UsersGames]

CREATE TRIGGER
	tr_RestrictInsetingItems
    ON [dbo].[UserGameItems]
    INSTEAD OF INSERT AS
BEGIN
    INSERT INTO
		[dbo].[UserGameItems]
    SELECT
		[dbo].[Items].[Id],
		[dbo].[UsersGames].[Id]
    FROM
		[Inserted]
    JOIN
		[dbo].[UsersGames]
        ON [Inserted].[UserGameId] = [dbo].[UsersGames].[Id]
    JOIN
		[dbo].[Items] 
        ON [Inserted].[ItemId] = [dbo].[Items].[Id]
    WHERE [dbo].[UsersGames].[Level] >= [dbo].[Items].[MinLevel]
END

GO

---

UPDATE
	[dbo].[UsersGames]
SET
	[dbo].[UsersGames].[Cash] += 50000
FROM
	[dbo].[UsersGames]
JOIN
	[dbo].[Games]
	ON [dbo].[Games].[Id] = [dbo].[UsersGames].[GameId]
JOIN
	[dbo].[Users]
	ON [dbo].[Users].[Id] = [dbo].[UsersGames].[UserId]
WHERE
	[dbo].[Games].[Name] LIKE 'Bali' AND
	[dbo].[Users].[Username] IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')

---

CREATE PROC
	usp_BuyItems(@Username NVARCHAR(50)) AS
BEGIN
    DECLARE @UserId INT =
						(SELECT [dbo].[Users].[Id]
						 FROM [dbo].[Users]
						 WHERE [dbo].[Users].[Username] = @Username)
    DECLARE @GameId INT=
						(SELECT [dbo].[Games].[Id]
						 FROM [dbo].[Games]
						 WHERE [dbo].[Games].[Name] = 'Bali')
    DECLARE @UserGameId INT=
						(SELECT [dbo].[UsersGames].[Id]
						 FROM [dbo].[UsersGames]
						 WHERE [dbo].[UsersGames].[UserId] = @UserId AND [dbo].[UsersGames].[GameId] = @GameId)
    DECLARE @UserGameLevel INT=
						(SELECT [dbo].[UsersGames].[Level]
						 FROM [dbo].[UsersGames]
						 WHERE [dbo].[UsersGames].[Id] = @UserGameId)
    DECLARE @IdCounter INT = 251;

    WHILE @IdCounter <= 539
        BEGIN
            DECLARE @ItemId INT = @IdCounter;
            DECLARE @ItemPrice money =
						(SELECT [dbo].[Items].[Price]
						 FROM [dbo].[Items]
						 WHERE [dbo].[Items].[Id] = @ItemId)
            DECLARE @ItemLevel INT=
						(SELECT [dbo].[Items].[MinLevel]
						 FROM [dbo].[Items]
						 WHERE [dbo].[Items].[Id] = @ItemId)
            DECLARE @UserGameCash money=
						(SELECT [dbo].[UsersGames].[Cash]
						 FROM [dbo].[UsersGames]
						 WHERE [dbo].[UsersGames].[Id] = @UserGameId)

            IF (@UserGameCash >= @ItemPrice AND @UserGameLevel >= @ItemLevel)
                BEGIN
                    UPDATE
						[dbo].[UsersGames]
                    SET
						[dbo].[UsersGames].[Cash] -= @ItemPrice
                    WHERE
						[dbo].[UsersGames].[Id] = @UserGameId
                    INSERT INTO
						[dbo].[UserGameItems]
                    VALUES
						(@ItemId, @UserGameId)
                END

            SET @IdCounter+=1;
            IF (@IdCounter = 300)
                BEGIN
                    SET @IdCounter = 501;
                END
        END
END

GO

EXEC usp_BuyItems 'baleremuda'
EXEC usp_BuyItems 'loosenoise'
EXEC usp_BuyItems 'inguinalself'
EXEC usp_BuyItems 'buildingdeltoid'
EXEC usp_BuyItems 'monoxidecos'

GO

---

SELECT
	[dbo].[Users].[Username] AS [Username],
    [dbo].[Games].[Name] AS [Name],
    [dbo].[UsersGames].[Cash] AS [Cash],
    [dbo].[Items].[Name] AS [Item Name]
FROM
	[dbo].[UsersGames]
JOIN
	[dbo].[Users]
	ON [dbo].[Users].[Id] = [dbo].[UsersGames].[UserId]
JOIN
	[dbo].[Games]
	ON [dbo].[Games].[Id] = [dbo].[UsersGames].[GameId]
JOIN
	[dbo].[Items]
	ON [dbo].[Games].[Name] = [dbo].[Items].[Name]
WHERE
	[dbo].[Games].[Name] = 'Bali'
ORDER BY
	[Username] ASC,
	[Item Name] ASC

GO