CREATE TABLE [dbo].[Relation_Producto_Combo]
(
	[ComboId] INT NOT NULL PRIMARY KEY, 
    [ProductoId] INT NULL, 
    CONSTRAINT [FK_Relation_Producto_To_Combo] FOREIGN KEY ([ComboId]) REFERENCES [Combo]([Id]),
    CONSTRAINT [FK_Relation_Combo_To_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [Producto]([Id]),
)
