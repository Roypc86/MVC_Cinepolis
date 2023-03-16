CREATE TABLE [dbo].[Sala]
(
	[Id] INT NOT NULL, 
    [Capacidad] INT NULL, 
    [CineId] INT NOT NULL, 
    CONSTRAINT Sala_key PRIMARY KEY (Id, CineId),
    CONSTRAINT [FK_Sala_To_Cine] FOREIGN KEY ([CineId]) REFERENCES [dbo].[Cine]([Id]) ON DELETE CASCADE
)
