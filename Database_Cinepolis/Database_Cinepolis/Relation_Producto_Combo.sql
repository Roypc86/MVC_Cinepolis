CREATE TABLE [dbo].[Relation_Producto_Combo]
(
	[ComboId] INT NOT NULL, 
    [ProductoId] INT NOT NULL, 
    CONSTRAINT relacion_combo_producto_pk PRIMARY KEY (ComboId, ProductoId),
    CONSTRAINT [FK_Relation_Combo_To_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [Producto]([Id]),
)
