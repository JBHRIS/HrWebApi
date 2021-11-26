CREATE TABLE [dbo].[EFFS_SELFWORK] (
    [AutoKey]   INT            IDENTITY (1, 1) NOT NULL,
    [yy]        INT            NULL,
    [seq]       INT            NULL,
    [nobr]      NVARCHAR (10)  NULL,
    [apprID]    INT            NULL,
    [num]       DECIMAL (5, 2) NULL,
    [keydate]   DATETIME       NULL,
    [mangCheck] BIT            NULL
);

