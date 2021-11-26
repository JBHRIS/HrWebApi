﻿CREATE TABLE [dbo].[RSMASTER] (
    [EMPID]    NVARCHAR (50) NOT NULL,
    [MASTER]   NVARCHAR (50) NOT NULL,
    [KEY_MAN]  NVARCHAR (50) NOT NULL,
    [KEY_DATE] DATETIME      NOT NULL,
    CONSTRAINT [PK_RSMASTER] PRIMARY KEY CLUSTERED ([EMPID] ASC)
);

