CREATE TABLE [dbo].[Combo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CineId] int NULL, 
    [EsAdulto] BIT NULL, 
    [JugueteId] INT NULL, 
    [TiqueteId] INT NULL, 
    CONSTRAINT [FK_Combo_To_Cine] FOREIGN KEY ([CineId]) REFERENCES [dbo].[Cine]([Id]),
    CONSTRAINT [FK_Combo_To_Juguete] FOREIGN KEY ([JugueteId]) REFERENCES [dbo].[Juguete]([Id]),
    CONSTRAINT [FK_Combo_To_Tiquete] FOREIGN KEY ([TiqueteId]) REFERENCES [dbo].[Tiquete]([Id])
)
