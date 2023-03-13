CREATE TABLE [dbo].[Pelicula]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(30) NULL, 
    [Genero] NVARCHAR(30) NULL, 
    [Director] NVARCHAR(30) NULL, 
    [EsAdultos] BIT NULL, 
    [Resumen] NVARCHAR(3000) NULL 
)
