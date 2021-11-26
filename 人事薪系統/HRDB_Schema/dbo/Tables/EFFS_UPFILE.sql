CREATE TABLE [dbo].[EFFS_UPFILE] (
    [autoKey]        INT            IDENTITY (1, 1) NOT NULL,
    [yy]             INT            NULL,
    [seq]            INT            NULL,
    [nobr]           NVARCHAR (10)  NULL,
    [upfilename]     NVARCHAR (500) NULL,
    [serverfilename] NVARCHAR (500) NULL,
    [filetype]       NVARCHAR (200) NULL,
    [filesize]       NVARCHAR (100) NULL,
    [upfiledate]     DATETIME       NULL,
    [filedesc]       VARCHAR (500)  NULL
);

