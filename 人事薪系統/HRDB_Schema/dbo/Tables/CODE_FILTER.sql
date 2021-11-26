﻿CREATE TABLE [dbo].[CODE_FILTER] (
    [SOURCE]    NVARCHAR (50)  NOT NULL,
    [CODE]      NVARCHAR (50)  NOT NULL,
    [CODEGROUP] NVARCHAR (50)  NOT NULL,
    [NOTE]      NVARCHAR (500) NOT NULL,
    [KEY_DATE]  DATETIME       NOT NULL,
    [KEY_MAN]   NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_CODE_FILTER] PRIMARY KEY CLUSTERED ([SOURCE] ASC, [CODE] ASC, [CODEGROUP] ASC)
);

