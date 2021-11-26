﻿CREATE TABLE [dbo].[U_ERROR] (
    [OCCUR_TIME] DATETIME        NOT NULL,
    [USER_ID]    NVARCHAR (50)   CONSTRAINT [DF_U_ERROR_USER_ID] DEFAULT ('') NOT NULL,
    [USER_NAME]  NVARCHAR (50)   NOT NULL,
    [SYSTEM]     NVARCHAR (50)   NOT NULL,
    [FORMNAME]   NVARCHAR (50)   NOT NULL,
    [ERRNO]      DECIMAL (16, 2) NOT NULL,
    [ERRMSG]     TEXT            NOT NULL,
    [ERRPGNAME]  TEXT            NOT NULL,
    [ERRPGCODE]  TEXT            NOT NULL,
    [ERRPGLINE]  DECIMAL (16, 2) NOT NULL,
    [AERROR]     TEXT            NOT NULL
);

