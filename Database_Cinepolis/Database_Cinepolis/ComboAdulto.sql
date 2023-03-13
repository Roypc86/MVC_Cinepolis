CREATE TABLE [dbo].[ComboAdulto]
(
	[ComboId] INT NOT NULL PRIMARY KEY, 
    [TiqueteId] INT NULL,
	CONSTRAINT [FK_ComboAdulto_To_Combo] FOREIGN KEY ([ComboId]) REFERENCES [dbo].[Combo]([Id]), 
    CONSTRAINT [FK_ComboAdulto_To_Tiquete] FOREIGN KEY ([TiqueteId]) REFERENCES [dbo].[Tiquete]([Id])

)
