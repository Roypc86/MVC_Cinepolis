CREATE TABLE [dbo].[ComboNino]
(
	[ComboId] INT NOT NULL PRIMARY KEY, 
    [JugueteId] INT NULL, 
    CONSTRAINT [FK_ComboNino_To_Combo] FOREIGN KEY ([ComboId]) REFERENCES [Combo]([Id]),
    CONSTRAINT [FK_ComboNino_To_JugueteId] FOREIGN KEY ([JugueteId]) REFERENCES [Juguete]([Id])
)
