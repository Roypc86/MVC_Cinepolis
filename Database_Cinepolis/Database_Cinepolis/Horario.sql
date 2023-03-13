﻿CREATE TABLE [dbo].[Horario]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Fecha] DATE NULL, 
    [Hora inicial] TIME NULL, 
    [Hora final] TIME NULL, 
    [SalaId] INT NULL, 
    [PeliculaId] INT NULL, 
    CONSTRAINT [FK_Horario_To_Sala] FOREIGN KEY ([SalaId]) REFERENCES [dbo].[Sala]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_Horario_To_Pelicula] FOREIGN KEY ([PeliculaId]) REFERENCES [dbo].[Pelicula]([Id]) ON DELETE SET NULL
)
