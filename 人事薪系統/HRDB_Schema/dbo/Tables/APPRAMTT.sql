﻿CREATE TABLE [dbo].[APPRAMTT] (
    [DEPTM]     NVARCHAR (50)   NOT NULL,
    [NOBR]      NVARCHAR (50)   NOT NULL,
    [YYMM]      NVARCHAR (50)   NOT NULL,
    [SER]       NVARCHAR (50)   NOT NULL,
    [AMT]       DECIMAL (16, 2) NOT NULL,
    [AMT1]      DECIMAL (16, 2) CONSTRAINT [DF_APPRAMTT_AMT1] DEFAULT ((0)) NOT NULL,
    [AMT2]      DECIMAL (16, 2) CONSTRAINT [DF_APPRAMTT_AMT2] DEFAULT ((0)) NOT NULL,
    [AMT3]      DECIMAL (16, 2) CONSTRAINT [DF_APPRAMTT_AMT3] DEFAULT ((0)) NOT NULL,
    [DAMT]      DECIMAL (16, 2) CONSTRAINT [DF_APPRAMTT_DAMT] DEFAULT ((0)) NOT NULL,
    [ABSAMT]    DECIMAL (16, 2) CONSTRAINT [DF_APPRAMTT_ABSAMT] DEFAULT ((0)) NOT NULL,
    [ABSPOT]    DECIMAL (16, 2) CONSTRAINT [DF_APPRAMTT_ABSPOT] DEFAULT ((0)) NOT NULL,
    [KEY_DATE]  DATETIME        CONSTRAINT [DF_APPRAMTT_KEY_DATE] DEFAULT (getdate()) NOT NULL,
    [KEY_MAN]   NVARCHAR (50)   CONSTRAINT [DF_APPRAMTT_KEY_MAN] DEFAULT ('') NOT NULL,
    [DI]        NVARCHAR (50)   CONSTRAINT [DF_APPRAMTT_DI] DEFAULT ('') NOT NULL,
    [SYSCREATE] BIT             CONSTRAINT [DF_APPRAMTT_SYSCREATE] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_APPRAMTT] PRIMARY KEY CLUSTERED ([DEPTM] ASC, [NOBR] ASC, [YYMM] ASC, [SER] ASC)
);

