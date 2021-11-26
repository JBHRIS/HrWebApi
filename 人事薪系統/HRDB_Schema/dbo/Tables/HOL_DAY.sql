﻿CREATE TABLE [dbo].[HOL_DAY] (
    [ADATE]     DATETIME      NOT NULL,
    [ATYPE]     NVARCHAR (50) NOT NULL,
    [KEY_MAN]   NVARCHAR (50) NOT NULL,
    [KEY_DATE]  DATETIME      NOT NULL,
    [HOLI_CODE] NVARCHAR (50) CONSTRAINT [DF_HOL_DAY_HOLI_CODE] DEFAULT ('') NOT NULL,
    [ROTE]      NVARCHAR (50) CONSTRAINT [DF_HOL_DAY_ROTE] DEFAULT ('') NOT NULL,
    [OTRATECD]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_HOL_DAY] PRIMARY KEY CLUSTERED ([ADATE] ASC, [HOLI_CODE] ASC, [ROTE] ASC)
);

