﻿CREATE TABLE [dbo].[RSREJOB] (
    [RESNO]     NVARCHAR (50)  NOT NULL,
    [RESNAME]   NVARCHAR (50)  NOT NULL,
    [RESCONDIT] NVARCHAR (250) NOT NULL,
    [KEY_MAN]   NVARCHAR (50)  NOT NULL,
    [KEY_DATE]  DATETIME       NOT NULL,
    [JOB]       NVARCHAR (50)  CONSTRAINT [DF_RSREJOB_JOB] DEFAULT ('') NOT NULL
);

