﻿/*
Deployment script for Database_Cinepolis

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Database_Cinepolis"
:setvar DefaultFilePrefix "Database_Cinepolis"
:setvar DefaultDataPath "C:\Users\XPC\AppData\Local\Microsoft\VisualStudio\SSDT\Database_Cinepolis"
:setvar DefaultLogPath "C:\Users\XPC\AppData\Local\Microsoft\VisualStudio\SSDT\Database_Cinepolis"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_Combo_To_Juguete]...';


GO
ALTER TABLE [dbo].[Combo] DROP CONSTRAINT [FK_Combo_To_Juguete];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_ComboNino_To_JugueteId]...';


GO
ALTER TABLE [dbo].[ComboNino] DROP CONSTRAINT [FK_ComboNino_To_JugueteId];


GO
PRINT N'Starting rebuilding table [dbo].[Juguete]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Juguete] (
    [Id]     INT        IDENTITY (1, 1) NOT NULL,
    [Nombre] NCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Juguete])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Juguete] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Juguete] ([Id], [Nombre])
        SELECT   [Id],
                 [Nombre]
        FROM     [dbo].[Juguete]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Juguete] OFF;
    END

DROP TABLE [dbo].[Juguete];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Juguete]', N'Juguete';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating Foreign Key [dbo].[FK_Combo_To_Juguete]...';


GO
ALTER TABLE [dbo].[Combo] WITH NOCHECK
    ADD CONSTRAINT [FK_Combo_To_Juguete] FOREIGN KEY ([JugueteId]) REFERENCES [dbo].[Juguete] ([Id]);


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------

DELETE FROM Accion;
DBCC CHECKIDENT ('Accion', RESEED, 0);
DELETE FROM Actor;
DBCC CHECKIDENT ('Actor', RESEED, 0);

DELETE FROM Cine;
DBCC CHECKIDENT ('Cine', RESEED, 0);


*/

--Datos Cine
MERGE INTO Cine AS Target
USING (VALUES
 (1, 'Cinepolis 1', 'San José, Desampados'),
 (2, 'Cinepolis 2', 'San José, Acosta')
)
AS Source ([Id], Nombre, Ubicacion)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Nombre, Ubicacion)
VALUES (Nombre, Ubicacion);

--Datos Pelicula
MERGE INTO Pelicula AS Target
USING (VALUES
 (1, 'Avatar', 'Acción y Aventura', 'James Cameron', 1, 'Avatar (comercializada como Avatar de James Cameron) es una película épica de ciencia ficción militar y animación estadounidense de 2009,6​7​ escrita, producida y dirigida por James Cameron y protagonizada por [Sam Worthington], [Zoe Saldaña], [Sigourney Weaver], Stephen Lang y Michelle Rodriguez.'),
 (2, 'Gato con botas', 'Comedia y Aventura', 'Chris Miller', 0, 'Un pobre molinero fallece dejando como única herencia al pequeño de sus hijos un gato. El joven decide quedarse con él y éste le promete que si confía en él y le consigue un par de botas y un saco, saldrán de la pobreza. El astuto gato se hace pasar por siervo de un gran marqués impresionando con sus regalos al rey. Luego engaña a un malvado ogro cambiaformas para devorarlo, haciéndose con su castillo y sus tierras y prepara un encuentro entre su joven amo, el nuevo marqués de Carabás, y la familia real, fingiendo que ha sido asaltado. Así, el joven acaba convertido en un noble y casándose con la princesa gracias al ingenio de su gato.'),
 (3, 'Maverick', 'Acción',  'Joseph Kosinski', 1, 'Tras más de treinta años de servicio como uno de los mejores aviadores de la Armada, Pete “Maverick” Mitchell (Tom Cruise) está en su casa, forzando los límites como valiente piloto de pruebas y esquivando el ascenso de rango que le dejaría en tierra. En el transcurso de unas sesiones de formación para que un destacamento de graduados de TOPGUN llevase a cabo una misión especializada que ningún piloto vivo había realizado, Maverick se encuentra con el teniente Bradley Bradshaw (Miles Teller), cuyo indicativo de llamada es “Rooster”, el hijo del difunto amigo de Maverick y oficial de intercepción y radar, el teniente Nick Bradshaw, también conocido como “Goose”.'),
 (4, 'Toy Story 3', 'Comedia',  'Lee Unkrich', 0, 'Toy Story 3 es la tercera película de la saga de animación Toy Story. La película fue distribuida en cines en formato analógico, digital y Disney Digital 3D.')
)
AS Source ([Id], Nombre, Genero, Director, EsAdultos, Resumen)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Nombre, Genero, Director, EsAdultos, Resumen)
VALUES (Nombre, Genero, Director, EsAdultos, Resumen);

--Datos Accion
MERGE INTO Accion AS Target
USING (VALUES
 (1, 'Sangre', 1),
 (2, 'Lenguaje inapropiado', 1),
 (3, 'Escenas inapropiadas', 3),
 (4, 'Lenguaje inapropiado', 3)
)
AS Source ([Id], Nombre, PeliculaId)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Nombre, PeliculaId)
VALUES (Nombre, PeliculaId);


--Datos Actores
MERGE INTO Actor AS Target
USING (VALUES
 (1, 'Thomas Cruise Mapother'),
 (2, 'Glen Power Jr')
)
AS Source ([Id], Nombre_Apellidos)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, Nombre_Apellidos)
VALUES (Id, Nombre_Apellidos);

--Datos relación Actor-Pelicula
MERGE INTO Relacion_Pelicula_Actor AS Target
USING (VALUES
 (3, 1),
 (3, 2)
)
AS Source (PeliculaId, ActorId)
ON Target.PeliculaId = Source.PeliculaId
WHEN NOT MATCHED BY TARGET THEN
INSERT (PeliculaId, ActorId)
VALUES (PeliculaId, ActorId);


--Datos Sala
MERGE INTO Sala AS Target
USING (VALUES
 (1, 21, 1),
 (2, 23, 1),
 (3, 21, 2),
 (4, 32, 2)
)
AS Source ([Id], Capacidad, CineId)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id], Capacidad, CineId)
VALUES ([Id], Capacidad, CineId);

--Datos Horario
MERGE INTO Horario AS Target
USING (VALUES
 (1, '2023-03-13', '17:30', '20:00', 1, 1),
 (2, '2023-03-13', '20:30', '23:00', 1, 1),
 (3, '2023-03-14', '17:30', '20:00', 2, 2),
 (4, '2023-03-14', '17:30', '20:00', 1, 3)
)
AS Source ([Id], Fecha, Hora_inicial, Hora_final, SalaId, PeliculaId)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Fecha, Hora_inicial, Hora_final, SalaId, PeliculaId)
VALUES (Fecha, Hora_inicial, Hora_final, SalaId, PeliculaId);

--Datos Producto
MERGE INTO Producto AS Target
USING (VALUES
 (1, 'Palomitas de caramelo'),
 (2, 'Papas'),
 (3, 'Refresco'),
 (4, 'Hot dog')
)
AS Source ([Id], Nombre)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Nombre)
VALUES (Nombre);

--Datos Juguete
MERGE INTO Juguete AS Target
USING (VALUES
 (1, 'Niño avatar'),
 (2, 'Rex'),
 (3, 'Jet'),
 (4, 'Gato')
)
AS Source ([Id], Nombre)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Nombre)
VALUES (Nombre);

--Datos Tiquete
MERGE INTO Tiquete AS Target
USING (VALUES
 (1, 'Viaje'),
 (2, 'Dinero'),
 (3, 'Carro')
)
AS Source ([Id], Nombre)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Nombre)
VALUES (Nombre);

--Datos Combo
MERGE INTO Combo AS Target
USING (VALUES
 (1, 1, 0, 1, NULL),
 (2, 1, 0, 2, NULL),
 (3, 1, 1, NULL, 1),
 (4, 1, 1, NULL, 2),
 (5, 2, 0, 3, NULL),
 (6, 2, 1, NULL, 4)
)
AS Source ([Id], CineId, EsAdulto, JugueteId, TiqueteId)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, CineId, EsAdulto, JugueteId, TiqueteId)
VALUES (Id, CineId, EsAdulto, JugueteId, TiqueteId);
GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Combo] WITH CHECK CHECK CONSTRAINT [FK_Combo_To_Juguete];


GO
PRINT N'Update complete.';


GO
