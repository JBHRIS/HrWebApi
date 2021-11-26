﻿CREATE TABLE [dbo].[HOLICD] (
    [HOLI_CODE]      NVARCHAR (50) NOT NULL,
    [HOLI_NAME]      NVARCHAR (50) NOT NULL,
    [KEY_MAN]        NVARCHAR (50) NOT NULL,
    [KEY_DATE]       DATETIME      NOT NULL,
    [NOSET]          BIT           NOT NULL,
    [DATE_CODE]      NVARCHAR (50) NOT NULL,
    [HOLI_CODE_DISP] NVARCHAR (50) NULL,
    CONSTRAINT [PK_HOLICD] PRIMARY KEY CLUSTERED ([HOLI_CODE] ASC)
);

