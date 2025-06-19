BEGIN TRANSACTION;
CREATE TABLE [TB_GENERO] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_GENERO] PRIMARY KEY ([Id])
);

CREATE TABLE [TB_MUSICO_GENERO] (
    [MusicoId] int NOT NULL,
    [GeneroId] int NOT NULL,
    CONSTRAINT [PK_TB_MUSICO_GENERO] PRIMARY KEY ([MusicoId], [GeneroId]),
    CONSTRAINT [FK_TB_MUSICO_GENERO_TB_GENERO_GeneroId] FOREIGN KEY ([GeneroId]) REFERENCES [TB_GENERO] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TB_MUSICO_GENERO_TB_MUSICOS_MusicoId] FOREIGN KEY ([MusicoId]) REFERENCES [TB_MUSICOS] ([Id]) ON DELETE CASCADE
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_GENERO]'))
    SET IDENTITY_INSERT [TB_GENERO] ON;
INSERT INTO [TB_GENERO] ([Id], [Nome])
VALUES (1, 'Contry'),
(2, 'Pop'),
(3, 'Rap'),
(4, 'Funk'),
(5, 'Pagode'),
(6, 'R&B');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_GENERO]'))
    SET IDENTITY_INSERT [TB_GENERO] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GeneroId', N'MusicoId') AND [object_id] = OBJECT_ID(N'[TB_MUSICO_GENERO]'))
    SET IDENTITY_INSERT [TB_MUSICO_GENERO] ON;
INSERT INTO [TB_MUSICO_GENERO] ([GeneroId], [MusicoId])
VALUES (1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(6, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GeneroId', N'MusicoId') AND [object_id] = OBJECT_ID(N'[TB_MUSICO_GENERO]'))
    SET IDENTITY_INSERT [TB_MUSICO_GENERO] OFF;

CREATE INDEX [IX_TB_MUSICO_GENERO_GeneroId] ON [TB_MUSICO_GENERO] ([GeneroId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250618235152_genero', N'9.0.6');

COMMIT;
GO

