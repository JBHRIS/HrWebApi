CREATE TABLE [dbo].[EFFS_ASSIGNAPPEND] (
    [AutoKey]    INT            IDENTITY (1, 1) NOT NULL,
    [yy]         INT            NULL,
    [seq]        INT            NULL,
    [nobr]       NVARCHAR (10)  NULL,
    [mangnobr]   NVARCHAR (10)  NULL,
    [mangdept]   NVARCHAR (100) NULL,
    [mangjob]    NVARCHAR (100) NULL,
    [assignnobr] NVARCHAR (10)  NULL,
    [keydate]    DATETIME       NULL,
    [extendday]  INT            NULL
);

