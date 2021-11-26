CREATE TABLE [dbo].[EFFS_MangFNums] (
    [autoKey]  INT            IDENTITY (1, 1) NOT NULL,
    [yy]       INT            NULL,
    [sql]      INT            NULL,
    [nobr]     NVARCHAR (50)  NULL,
    [mangnobr] NVARCHAR (50)  NULL,
    [mangdept] NVARCHAR (50)  NULL,
    [keydate]  DATETIME       NULL,
    [num]      DECIMAL (5, 2) NULL,
    [O1]       NTEXT          NULL,
    [O2]       NVARCHAR (MAX) NULL
);



