CREATE TABLE [dbo].[EFFS_MANGINTERVIEW] (
    [AutoKey]  INT           IDENTITY (1, 1) NOT NULL,
    [yy]       INT           NULL,
    [seq]      INT           NULL,
    [nobr]     NVARCHAR (50) NULL,
    [mangnobr] NVARCHAR (50) NULL,
    [INTERID]  NVARCHAR (10) NULL,
    [note]     NTEXT         NULL,
    [keyDate]  DATETIME      NULL
);

