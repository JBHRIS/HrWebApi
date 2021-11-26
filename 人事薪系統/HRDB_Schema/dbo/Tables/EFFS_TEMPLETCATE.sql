CREATE TABLE [dbo].[EFFS_TEMPLETCATE] (
    [autoKey]   INT           IDENTITY (1, 1) NOT NULL,
    [templetID] NVARCHAR (4)  NOT NULL,
    [effcateID] NVARCHAR (4)  NOT NULL,
    [order]     INT           NOT NULL,
    [typeID]    NVARCHAR (50) NULL
);

