BEGIN TRANSACTION;
CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Email] varchar(200) NOT NULL,
    [Endereco] varchar(200) NOT NULL,
    [Senha] varchar(200) NOT NULL,
    [Telefone] varchar(200) NOT NULL,
    [Bio] varchar(200) NOT NULL,
    [DataCriacao] datetime2 NULL,
    [FotoPerfil] varbinary(max) NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);

UPDATE [TB_MUSICOS] SET [UsuarioId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bio', N'DataCriacao', N'Email', N'Endereco', N'FotoPerfil', N'Nome', N'Senha', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] ON;
INSERT INTO [Usuario] ([Id], [Bio], [DataCriacao], [Email], [Endereco], [FotoPerfil], [Nome], [Senha], [Telefone])
VALUES (1, 'Guitarrista solo', '2024-01-01T00:00:00.0000000', 'jeff@email.com', 'Rua Teste', NULL, 'Jefferson', '123456', '11999999999');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bio', N'DataCriacao', N'Email', N'Endereco', N'FotoPerfil', N'Nome', N'Senha', N'Telefone') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] OFF;

CREATE UNIQUE INDEX [IX_TB_MUSICOS_UsuarioId] ON [TB_MUSICOS] ([UsuarioId]);

ALTER TABLE [TB_MUSICOS] ADD CONSTRAINT [FK_TB_MUSICOS_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250618225150_Usuario_Musico', N'9.0.6');

COMMIT;
GO

