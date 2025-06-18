IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_MUSICOS] (
    [Id] int NOT NULL IDENTITY,
    [UsuarioId] int NOT NULL,
    [Apelido] varchar(200) NOT NULL,
    [Cpf] varchar(200) NOT NULL,
    [Classe] int NOT NULL,
    CONSTRAINT [PK_TB_MUSICOS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apelido', N'Classe', N'Cpf', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[TB_MUSICOS]'))
    SET IDENTITY_INSERT [TB_MUSICOS] ON;
INSERT INTO [TB_MUSICOS] ([Id], [Apelido], [Classe], [Cpf], [UsuarioId])
VALUES (1, 'Jeff', 1, '234.234.234-23', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apelido', N'Classe', N'Cpf', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[TB_MUSICOS]'))
    SET IDENTITY_INSERT [TB_MUSICOS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250618221515_InitialMigration', N'9.0.6');

COMMIT;
GO

