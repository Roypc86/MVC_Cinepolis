CREATE TABLE [dbo].[PeliculaNinos]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Resumen] NVARCHAR(3000) NOT NULL DEFAULT 'Hola amiguitos', 
    CONSTRAINT [FK_PeliculaNinos_To_Pelicula] FOREIGN KEY ([Id]) REFERENCES [dbo].[Pelicula]([Id]) ON DELETE CASCADE
	
)
