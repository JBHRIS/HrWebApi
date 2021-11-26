CREATE TABLE [dbo].[EFFS_Mang_Check] (
    [AutoKey]  INT           IDENTITY (1, 1) NOT NULL,
    [yy]       INT           NULL,
    [seq]      INT           NULL,
    [nobr]     NVARCHAR (50) NULL,
    [mangnobr] NVARCHAR (50) NULL,
    [Type]     NVARCHAR (50) NULL,
    [rate]     INT           NULL,
    CONSTRAINT [PK_EFFS_Mang_Check] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

