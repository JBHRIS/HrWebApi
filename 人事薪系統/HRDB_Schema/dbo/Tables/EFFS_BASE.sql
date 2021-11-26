CREATE TABLE [dbo].[EFFS_BASE] (
    [effbaseID]   NVARCHAR (50) NOT NULL,
    [yy]          NVARCHAR (4)  NULL,
    [seq]         NVARCHAR (1)  NULL,
    [templetID]   NVARCHAR (50) NULL,
    [nobr]        NVARCHAR (50) NULL,
    [dept]        NVARCHAR (50) NULL,
    [depta]       NVARCHAR (50) NULL,
    [depts]       NVARCHAR (50) NULL,
    [JOB]         NVARCHAR (50) NULL,
    [jobl]        NVARCHAR (50) NULL,
    [stddate]     DATETIME      NULL,
    [enddate]     DATETIME      NULL,
    [firstdate]   DATETIME      NULL,
    [deptorder]   NVARCHAR (50) NULL,
    [jobplan]     NTEXT         NULL,
    [mangfinish]  BIT           NULL,
    [isdeff]      BIT           NULL,
    [effsfinally] NVARCHAR (50) NULL,
    [effsgroupID] NVARCHAR (50) NULL,
    CONSTRAINT [PK_EFFS_BASE] PRIMARY KEY CLUSTERED ([effbaseID] ASC)
);

