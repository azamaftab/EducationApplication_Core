IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Classes] (
    [ClassID] int NOT NULL IDENTITY,
    [ClassName] nvarchar(max) NULL,
    CONSTRAINT [PK_Classes] PRIMARY KEY ([ClassID])
);

GO

CREATE TABLE [Students] (
    [StudentID] int NOT NULL IDENTITY,
    [StudentName] nvarchar(max) NULL,
    [ClassID] int NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([StudentID]),
    CONSTRAINT [FK_Students_Classes_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [Classes] ([ClassID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Students_ClassID] ON [Students] ([ClassID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190124135101_Init Migration', N'2.2.1-servicing-10028');

GO

