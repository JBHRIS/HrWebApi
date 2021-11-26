﻿CREATE TABLE [dbo].[SALARYCALC] (
    [GUID]   UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [SOURCE] NVARCHAR (50)    NOT NULL,
    [USERID] NVARCHAR (50)    NOT NULL,
    [TIMEB]  DATETIME         NULL,
    [TIMEE]  DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([GUID] ASC)
);

