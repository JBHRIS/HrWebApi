CREATE TABLE [dbo].[EFFS_CATEITEM] (
    [effsID]    NVARCHAR (4) NOT NULL,
    [effcateID] NVARCHAR (4) NULL,
    [effsName]  NTEXT        NULL,
    [effnote]   NTEXT        NULL,
    CONSTRAINT [PK_EFFS_CATEITEM] PRIMARY KEY CLUSTERED ([effsID] ASC)
);

