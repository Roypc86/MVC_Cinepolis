CREATE TABLE [dbo].[Accion]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(50) NULL, 
    [PeliculaId] INT NULL, 
    CONSTRAINT [FK_Accion_To_Pelicula] FOREIGN KEY ([PeliculaId]) REFERENCES [dbo].[Pelicula]([Id]) ON DELETE CASCADE
)
