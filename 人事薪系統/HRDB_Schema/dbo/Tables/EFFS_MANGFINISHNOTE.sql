CREATE TABLE [dbo].[EFFS_MANGFINISHNOTE] (
    [AutoKey] INT           IDENTITY (1, 1) NOT NULL,
    [yy]      INT           NULL,
    [seq]     INT           NULL,
    [nobr]    NVARCHAR (50) NULL,
    [dept]    NVARCHAR (50) NULL,
    [job]     NVARCHAR (50) NULL,
    [keydate] DATETIME      NULL,
    [note]    NTEXT         NULL
);

