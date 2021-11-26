CREATE TABLE [dbo].[EFFS_MANGAPPEND] (
    [AutoKey]      INT            IDENTITY (1, 1) NOT NULL,
    [yy]           INT            NULL,
    [seq]          INT            NULL,
    [nobr]         NVARCHAR (10)  NULL,
    [mangnobr]     NVARCHAR (10)  NULL,
    [mangdept]     NVARCHAR (50)  NULL,
    [mangjob]      NVARCHAR (50)  NULL,
    [apptype]      NVARCHAR (10)  NULL,
    [appstddate]   DATETIME       NULL,
    [appenddate]   DATETIME       NULL,
    [appendfinish] BIT            NULL,
    [note]         NVARCHAR (MAX) NULL,
    [appendType]   BIT            NULL
);

