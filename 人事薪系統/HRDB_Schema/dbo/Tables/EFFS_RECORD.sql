CREATE TABLE [dbo].[EFFS_RECORD] (
    [AutoKey]  INT           IDENTITY (1, 1) NOT NULL,
    [nobr]     NVARCHAR (50) NULL,
    [type]     NVARCHAR (6)  NULL,
    [record]   NTEXT         NULL,
    [adate]    DATETIME      NULL,
    [keydate]  DATETIME      NULL,
    [effscate] NVARCHAR (10) NULL,
    [mangname] NVARCHAR (50) NULL
);

