CREATE TABLE [dbo].[EFFS_SELFPlan] (
    [AutoKey]   INT           IDENTITY (1, 1) NOT NULL,
    [yy]        INT           NULL,
    [seq]       INT           NULL,
    [nobr]      NVARCHAR (10) NULL,
    [note]      NTEXT         NULL,
    [keydate]   DATETIME      NULL,
    [mangCheck] BIT           NULL,
    [note1]     NTEXT         NULL,
    [note2]     NTEXT         NULL
);

