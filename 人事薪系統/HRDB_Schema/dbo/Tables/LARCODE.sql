﻿CREATE TABLE [dbo].[LARCODE] (
    [RATE_CODE]  NVARCHAR (50)   NOT NULL,
    [RATE_NAME]  NVARCHAR (50)   NOT NULL,
    [NORMALRATE] DECIMAL (16, 4) NOT NULL,
    [LOSJOBRATE] DECIMAL (16, 4) NOT NULL,
    [JOBACCRATE] DECIMAL (16, 4) NOT NULL,
    [SELFCHARGE] DECIMAL (16, 2) NOT NULL,
    [COMPCHARGE] DECIMAL (16, 2) NOT NULL,
    [PARTIAL]    DECIMAL (16, 2) NOT NULL,
    [KEY_MAN]    NVARCHAR (50)   NOT NULL,
    [KEY_DATE]   DATETIME        NOT NULL,
    [ADATE]      DATETIME        NOT NULL,
    [NOFUND]     BIT             CONSTRAINT [DF_LARCODE_NOFUND] DEFAULT ((0)) NOT NULL,
    [NODISASTER] BIT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_LARCODE] PRIMARY KEY CLUSTERED ([RATE_CODE] ASC)
);



