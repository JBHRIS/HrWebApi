﻿CREATE TABLE [dbo].[U_LOGIN] (
    [IN_TIME]   DATETIME      NOT NULL,
    [USER_ID]   NVARCHAR (50) NULL,
    [USER_NAME] NVARCHAR (50) NULL,
    [WORKADR]   NVARCHAR (50) NULL,
    [PROCSUPER] BIT           NULL,
    [MANGSUPER] BIT           NULL,
    [SUPER]     BIT           NULL,
    [SYSTEM]    NVARCHAR (50) NULL,
    CONSTRAINT [PK_U_LOGIN] PRIMARY KEY CLUSTERED ([IN_TIME] ASC)
);

