CREATE TABLE [dbo].[Horario]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Fecha] DATE NULL, 
    [Hora_inicial] TIME NULL, 
    [Hora_final] TIME NULL, 
    [SalaId] INT NULL, 
    [CineId] INT NULL, 
    [PeliculaId] INT NULL, 
    CONSTRAINT [FK_Horario_To_Sala] FOREIGN KEY ([SalaId],[CineId]) REFERENCES [dbo].[Sala]([Id], [CineId]) ON DELETE CASCADE, 
    
    CONSTRAINT [FK_Horario_To_Pelicula] FOREIGN KEY ([PeliculaId]) REFERENCES [dbo].[Pelicula]([Id]) ON DELETE CASCADE
)
