CREATE TABLE [dbo].[Relacion_Pelicula_Actor]
(
	[IdPelicula] INT NOT NULL PRIMARY KEY, 
    [IdActor] INT NULL, 
    CONSTRAINT [FK_Relacion_To_Pelicula] FOREIGN KEY ([IdPelicula]) REFERENCES [dbo].[Pelicula]([Id]),
    CONSTRAINT [FK_Relacion_To_Actor] FOREIGN KEY ([IdActor]) REFERENCES [dbo].[Actor]([Id])
)
