ALTER TABLE [dbo].[Minions] ADD TownId int

ALTER TABLE [dbo].[Minions]
ADD CONSTRAINT FK_Minions_Towns
FOREIGN KEY (TownId)
REFERENCES Towns(Id);