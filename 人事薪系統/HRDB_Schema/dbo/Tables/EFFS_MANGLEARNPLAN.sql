CREATE TABLE [dbo].[EFFS_MANGLEARNPLAN] (
    [AuotKey]  INT             IDENTITY (1, 1) NOT NULL,
    [yy]       INT             NULL,
    [seq]      INT             NULL,
    [nobr]     NVARCHAR (10)   NULL,
    [mangnobr] NVARCHAR (10)   NULL,
    [mangdept] NVARCHAR (10)   NULL,
    [mangjob]  NVARCHAR (10)   NULL,
    [note1]    NVARCHAR (1000) NULL,
    [note2]    NVARCHAR (1000) NULL,
    [note3]    NVARCHAR (1000) NULL,
    [note4]    NVARCHAR (1000) NULL,
    [note5]    NVARCHAR (1000) NULL
);

