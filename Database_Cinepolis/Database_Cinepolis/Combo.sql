CREATE TABLE [dbo].[Combo]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [CineId] int NULL, 
    CONSTRAINT [FK_Combo_To_Cine] FOREIGN KEY ([CineId]) REFERENCES [dbo].[Cine]([Id])
)
