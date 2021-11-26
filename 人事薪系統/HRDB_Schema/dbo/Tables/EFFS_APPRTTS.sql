CREATE TABLE [dbo].[EFFS_APPRTTS] (
    [autoKey]     INT            IDENTITY (1, 1) NOT NULL,
    [EffS_APPRID] INT            NOT NULL,
    [works]       NTEXT          NULL,
    [standard]    NVARCHAR (200) NULL,
    [rate]        NVARCHAR (50)  NULL,
    [appr]        NTEXT          NULL,
    [bespeak]     NVARCHAR (200) NULL,
    [reality]     NVARCHAR (200) NULL,
    [keydate]     DATETIME       NULL,
    [original]    NVARCHAR (10)  NULL,
    [type]        NVARCHAR (10)  NULL,
    [adate]       DATETIME       NULL,
    [ddate]       DATETIME       NULL
);

