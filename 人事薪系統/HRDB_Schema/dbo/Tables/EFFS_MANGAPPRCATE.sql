CREATE TABLE [dbo].[EFFS_MANGAPPRCATE] (
    [AuotKey]  INT            IDENTITY (1, 1) NOT NULL,
    [yy]       INT            NULL,
    [seq]      INT            NULL,
    [nobr]     NVARCHAR (10)  NULL,
    [mangnobr] NVARCHAR (10)  NULL,
    [mangdept] NVARCHAR (100) NULL,
    [mangjob]  NVARCHAR (100) NULL,
    [apprID]   NVARCHAR (10)  NULL,
    [num]      DECIMAL (5, 2) NULL,
    [keydate]  DATETIME       NULL,
    [o1]       NTEXT          NULL,
    [o2]       NTEXT          NULL,
    [o3]       NTEXT          NULL,
    [o4]       NTEXT          NULL,
    [o5]       NTEXT          NULL
);

