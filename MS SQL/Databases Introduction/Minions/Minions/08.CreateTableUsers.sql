CREATE TABLE [dbo].[Users]
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO [dbo].[Users]
([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])

VALUES
('eggplantCancer', '123456', 123100, '1900-09-09 00:00:01', 0),
('stoneBee', '654321', 153100, '2012-12-12 12:12:12', 0),
('limeOrDime', '111111', 131120, '2022-03-04 04:03:22', 1),
('whatHaveWeDone', '666999', 133133, '2008-10-07 10:50:40', 0),
('randomBot', '999666', 11321764, '2010-10-11 10:10:40', 0);

UPDATE [dbo].[Users]
SET Password = '1234567890'
WHERE Id = 2;

---

INSERT INTO [dbo].[Users]
([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])

VALUES
('testUser', '222', 2, '2022-10-10 22:22:22', 0)

---

INSERT INTO [dbo].[Users]
([Username], [Password], [ProfilePicture], [IsDeleted])

VALUES
('testUser2', '222222', 1 , 1)

---

INSERT INTO [dbo].[Users]
([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])

VALUES
('testUser3', '111111', 1, '2022-12-12 12:12:12', 0)

---

INSERT INTO [dbo].[Users]
([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])

VALUES
('testUser4', '1234567890', 11231, '2000-10-10 10:40:40', 0)

---

INSERT INTO [dbo].[Users]
([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])

VALUES
('testUser5', '0987654321', 11211131, '2010-10-10 10:40:40', 1)

---

SELECT * FROM [dbo].[Users]