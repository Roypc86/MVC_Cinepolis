CREATE TABLE [dbo].[PeliculaAdultos]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Resumen] NCHAR(10) NULL, 
    CONSTRAINT [FK_PeliculaAdultos_To_Pelicula] FOREIGN KEY ([Id]) REFERENCES [dbo].[Pelicula]([Id])
)
