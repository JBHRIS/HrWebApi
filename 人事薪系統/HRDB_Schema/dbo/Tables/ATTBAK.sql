﻿CREATE TABLE [dbo].[ATTBAK] (
    [NOBR]     NVARCHAR (50) NOT NULL,
    [ADATE]    DATETIME      NOT NULL,
    [KEY_MAN]  NVARCHAR (50) NOT NULL,
    [KEY_DATE] DATETIME      NOT NULL,
    CONSTRAINT [PK_ATTBAK] PRIMARY KEY CLUSTERED ([NOBR] ASC, [ADATE] ASC)
);

