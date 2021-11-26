﻿CREATE TABLE [dbo].[MAILWAIT] (
    [FORMNAME]  NVARCHAR (50) CONSTRAINT [DF_MAILWAIT_FORMNAME] DEFAULT ('') NOT NULL,
    [NOBR_REC]  NVARCHAR (50) CONSTRAINT [DF_MAILWAIT_NOBR_REC] DEFAULT ('') NOT NULL,
    [FORMNO]    NVARCHAR (50) CONSTRAINT [DF_MAILWAIT_FORMNO] DEFAULT ('') NOT NULL,
    [ADATE]     NVARCHAR (50) CONSTRAINT [DF_MAILWAIT_ADATE] DEFAULT ('') NOT NULL,
    [NOBR_SEND] NVARCHAR (50) CONSTRAINT [DF_MAILWAIT_NOBR_SEND] DEFAULT ('') NOT NULL,
    [OK_STAT]   NVARCHAR (50) CONSTRAINT [DF_MAILWAIT_OK_STAT] DEFAULT ('') NOT NULL,
    [SEND_TIME] DATETIME      CONSTRAINT [DF_MAILWAIT_SEND_TIME] DEFAULT (getdate()) NOT NULL,
    [OK_TIME]   DATETIME      CONSTRAINT [DF_MAILWAIT_OK_TIME] DEFAULT (getdate()) NOT NULL
);

