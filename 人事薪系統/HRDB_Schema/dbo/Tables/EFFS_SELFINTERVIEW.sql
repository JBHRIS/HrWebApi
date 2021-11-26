CREATE TABLE [dbo].[EFFS_SELFINTERVIEW] (
    [AutoKey]   INT           IDENTITY (1, 1) NOT NULL,
    [yy]        INT           NULL,
    [seq]       INT           NULL,
    [nobr]      NVARCHAR (10) NULL,
    [INTERID]   NVARCHAR (10) NULL,
    [note]      NTEXT         NULL,
    [keyDate]   DATETIME      NULL,
    [mangCheck] BIT           NULL
);

