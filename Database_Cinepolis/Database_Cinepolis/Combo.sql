﻿CREATE TABLE [dbo].[Combo]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [CineId] int NULL, 
    [EsAdulto] BIT NULL, 
    [Juguete] NVARCHAR(40) NULL, 
    [TiqueteId] INT NULL, 
    [Productos] NVARCHAR(200) NULL, 
    CONSTRAINT [FK_Combo_To_Cine] FOREIGN KEY ([CineId]) REFERENCES [dbo].[Cine]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Combo_To_Tiquete] FOREIGN KEY ([TiqueteId]) REFERENCES [dbo].[Tiquete]([Id])  ON DELETE CASCADE
)
