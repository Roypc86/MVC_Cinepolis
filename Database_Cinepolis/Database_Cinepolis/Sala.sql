CREATE TABLE [dbo].[Sala]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Capacidad] NCHAR(10) NULL, 
    [CineId] INT NULL, 
    CONSTRAINT [FK_Sala_To_Cine] FOREIGN KEY ([CineId]) REFERENCES [dbo].[Cine]([Id])
)
