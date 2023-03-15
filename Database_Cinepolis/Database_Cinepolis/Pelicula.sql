CREATE TABLE [dbo].[Pelicula]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(30) NULL, 
    [Genero] NVARCHAR(30) NULL, 
    [Director] NVARCHAR(30) NULL, 
    [EsAdultos] BIT NULL, 
    [Acciones] NVARCHAR(300) NULL, 
    [Actores] NVARCHAR(300) NULL,
    [Resumen] NVARCHAR(3000) NULL  
)
