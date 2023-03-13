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
 (1, 'Avatar', 'Acción y Aventura', 'James Cameron'),
 (2, 'Gato con botas', 'Comedia y Aventura', 'Chris Miller'),
 (3, 'Maverick', 'Acción',  'Joseph Kosinski'),
 (4, 'Toy Story 3', 'Comedia',  'Lee Unkrich')
)
AS Source ([Id], Nombre, Genero, Director)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Nombre, Genero, Director)
VALUES (Nombre, Genero, Director);

