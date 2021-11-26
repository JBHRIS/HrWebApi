CREATE TABLE [dbo].[EFFS_APPR] (
    [autoKey]       INT            IDENTITY (1, 1) NOT NULL,
    [nobr]          NVARCHAR (10)  NULL,
    [works]         NTEXT          NULL,
    [standard]      NTEXT          NULL,
    [rate]          NVARCHAR (50)  NULL,
    [appr]          NTEXT          NULL,
    [bespeak]       NTEXT          NULL,
    [reality]       NVARCHAR (200) NULL,
    [mangCheck]     BIT            NULL,
    [mangcheckDate] DATETIME       NULL,
    [mangname]      NVARCHAR (10)  NULL,
    [key_date]      DATETIME       NULL,
    [included]      BIT            NULL,
    [yy]            INT            NULL,
    [seq]           INT            NULL,
    [dept]          NVARCHAR (10)  NULL
);

