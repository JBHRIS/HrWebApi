﻿CREATE TABLE [dbo].[APTYPE] (
    [APTYPE]     NVARCHAR (50) NOT NULL,
    [APTYPENAME] NVARCHAR (50) NOT NULL,
    [KEY_DATE]   DATETIME      NOT NULL,
    [KEY_MAN]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_APTYPE] PRIMARY KEY CLUSTERED ([APTYPE] ASC)
);

