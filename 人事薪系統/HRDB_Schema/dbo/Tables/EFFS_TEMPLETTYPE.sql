CREATE TABLE [dbo].[EFFS_TEMPLETTYPE] (
    [autoKey]          INT            IDENTITY (1, 1) NOT NULL,
    [templetID]        NVARCHAR (4)   NULL,
    [type]             NVARCHAR (4)   NULL,
    [rate]             DECIMAL (6, 2) NULL,
    [order]            INT            NULL,
    [catename]         NTEXT          NULL,
    [catenote]         NTEXT          NULL,
    [cateitemname]     NTEXT          NULL,
    [cateitemnote]     NTEXT          NULL,
    [showcatename]     BIT            NULL,
    [showcatenote]     BIT            NULL,
    [showcateitemname] BIT            NULL,
    [showcateitemnote] BIT            NULL,
    [effsmode]         NVARCHAR (50)  NULL,
    [titleID]          NVARCHAR (50)  NULL
);

