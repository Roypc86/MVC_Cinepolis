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

--Datos Pelicula Adultos
MERGE INTO PeliculaAdultos AS Target
USING (VALUES
 (1, 'Avatar (comercializada como Avatar de James Cameron) es una película épica de ciencia ficción militar y animación estadounidense de 2009,6​7​ escrita, producida y dirigida por James Cameron y protagonizada por [Sam Worthington], [Zoe Saldaña], [Sigourney Weaver], Stephen Lang y Michelle Rodriguez.'),
 (3, 'Tras más de treinta años de servicio como uno de los mejores aviadores de la Armada, Pete “Maverick” Mitchell (Tom Cruise) está en su casa, forzando los límites como valiente piloto de pruebas y esquivando el ascenso de rango que le dejaría en tierra. En el transcurso de unas sesiones de formación para que un destacamento de graduados de TOPGUN llevase a cabo una misión especializada que ningún piloto vivo había realizado, Maverick se encuentra con el teniente Bradley Bradshaw (Miles Teller), cuyo indicativo de llamada es “Rooster”, el hijo del difunto amigo de Maverick y oficial de intercepción y radar, el teniente Nick Bradshaw, también conocido como “Goose”.')
)
AS Source ([Id], Resumen)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, Resumen)
VALUES (Id, Resumen);

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

--Datos Pelicula Niños
MERGE INTO PeliculaNinos AS Target
USING (VALUES
 (2, 'Un pobre molinero fallece dejando como única herencia al pequeño de sus hijos un gato. El joven decide quedarse con él y éste le promete que si confía en él y le consigue un par de botas y un saco, saldrán de la pobreza. El astuto gato se hace pasar por siervo de un gran marqués impresionando con sus regalos al rey. Luego engaña a un malvado ogro cambiaformas para devorarlo, haciéndose con su castillo y sus tierras y prepara un encuentro entre su joven amo, el nuevo marqués de Carabás, y la familia real, fingiendo que ha sido asaltado. Así, el joven acaba convertido en un noble y casándose con la princesa gracias al ingenio de su gato.'),
 (4, 'Toy Story 3 es la tercera película de la saga de animación Toy Story. La película fue distribuida en cines en formato analógico, digital y Disney Digital 3D.')
)
AS Source ([Id], Resumen)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, Resumen)
VALUES (Id, Resumen);

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

--Datos Combo
