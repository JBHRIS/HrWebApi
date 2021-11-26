CREATE TABLE [dbo].[EFFS_TITLEITEM] (
    [autoKey] INT           IDENTITY (1, 1) NOT NULL,
    [titleID] NVARCHAR (4)  NOT NULL,
    [title]   NVARCHAR (10) NOT NULL,
    [order]   INT           NOT NULL,
    [num]     INT           NULL
);

