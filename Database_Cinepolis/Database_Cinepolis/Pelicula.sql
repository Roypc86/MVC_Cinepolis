CREATE TABLE [dbo].[Pelicula]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(30) NULL, 
    [Genero] NVARCHAR(30) NULL, 
    [Director] NVARCHAR(30) NULL
)
