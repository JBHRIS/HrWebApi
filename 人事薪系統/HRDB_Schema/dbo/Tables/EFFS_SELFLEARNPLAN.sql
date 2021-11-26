CREATE TABLE [dbo].[EFFS_SELFLEARNPLAN] (
    [AutoKey]     INT           IDENTITY (1, 1) NOT NULL,
    [yy]          INT           NULL,
    [seq]         INT           NULL,
    [nobr]        NVARCHAR (10) NULL,
    [learnplanID] NVARCHAR (10) NULL,
    [note]        NTEXT         NULL
);

