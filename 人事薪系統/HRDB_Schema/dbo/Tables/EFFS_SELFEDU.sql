CREATE TABLE [dbo].[EFFS_SELFEDU] (
    [AutoKey]       INT           IDENTITY (1, 1) NOT NULL,
    [yy]            INT           NULL,
    [seq]           INT           NULL,
    [nobr]          NVARCHAR (10) NULL,
    [eduCateID]     NVARCHAR (10) NULL,
    [eduCateItemID] NVARCHAR (10) NULL,
    [other]         NTEXT         NULL,
    [keydate]       DATETIME      NULL
);

