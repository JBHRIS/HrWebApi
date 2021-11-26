CREATE TABLE [dbo].[EFFS_TEMPLETCATEITEM] (
    [autoKey]    INT            IDENTITY (1, 1) NOT NULL,
    [templetID]  NVARCHAR (4)   NOT NULL,
    [effsID]     NVARCHAR (4)   NOT NULL,
    [order]      INT            NOT NULL,
    [effsMinNum] DECIMAL (6, 2) NULL,
    [effsMaxNum] DECIMAL (6, 2) NULL,
    [rate]       DECIMAL (6, 2) NULL,
    [typeID]     NVARCHAR (50)  NULL,
    [effsCateID] NVARCHAR (50)  NULL
);

