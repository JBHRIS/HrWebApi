CREATE TABLE [dbo].[EFFS_SELFCATE] (
    [AutoKey]   INT            IDENTITY (1, 1) NOT NULL,
    [yy]        INT            NULL,
    [seq]       INT            NULL,
    [nobr]      NVARCHAR (10)  NULL,
    [cateID]    NVARCHAR (10)  NULL,
    [num]       DECIMAL (5, 2) NULL,
    [keyDate]   DATETIME       NULL,
    [mangCheck] BIT            NULL,
    [rate]      DECIMAL (5, 2) NULL,
    [o1]        NTEXT          NULL,
    [o2]        NTEXT          NULL,
    [o3]        NTEXT          NULL,
    [o4]        NTEXT          NULL,
    [o5]        NTEXT          NULL
);

