CREATE TABLE [dbo].[Relacion_Pelicula_Actor]
(
	[PeliculaId] INT NOT NULL, 
    [ActorId] INT NOT NULL, 
    CONSTRAINT relacion_pelicula_actor_pk PRIMARY KEY (PeliculaId, ActorId),
    CONSTRAINT [FK_Relacion_To_Pelicula] FOREIGN KEY ([PeliculaId]) REFERENCES [dbo].[Pelicula]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Relacion_To_Actor] FOREIGN KEY ([ActorId]) REFERENCES [dbo].[Actor]([Id]) ON DELETE CASCADE
)
