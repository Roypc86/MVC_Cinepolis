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
*/
MERGE INTO Director AS Target
USING (VALUES
 (1, 'James Cameron', 'Biografía de James Cameron'),
 (2, 'Chris Miller', 'Biografía de Chris Miller ')
)
AS Source ([Id], Nombre, Biografia)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Nombre, Biografia)
VALUES (Nombre, Biografia);