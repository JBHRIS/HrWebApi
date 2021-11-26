﻿CREATE TABLE [dbo].[INSGRLV] (
    [AMT]          DECIMAL (14, 4) NOT NULL,
    [B_AMT]        DECIMAL (14, 4) NOT NULL,
    [E_AMT]        DECIMAL (14, 4) NOT NULL,
    [EXPA]         DECIMAL (14, 4) NOT NULL,
    [EXPB]         DECIMAL (14, 4) NOT NULL,
    [EXPC]         DECIMAL (14, 4) NOT NULL,
    [EXPD]         DECIMAL (14, 4) NOT NULL,
    [EXTA]         DECIMAL (14, 4) NOT NULL,
    [EXTB]         DECIMAL (14, 4) NOT NULL,
    [EXTC]         DECIMAL (14, 4) NOT NULL,
    [EXTD]         DECIMAL (14, 4) NOT NULL,
    [KEY_MAN]      NVARCHAR (50)   NOT NULL,
    [KEY_DATE]     DATETIME        NOT NULL,
    [PLAN_NO]      NVARCHAR (50)   NOT NULL,
    [PLAN_NO_DISP] NVARCHAR (50)   NOT NULL,
    [ACCI_AMT]     DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_ACCI_AMT] DEFAULT ((0)) NOT NULL,
    [COM_EXPA]     DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_COM_EXPA] DEFAULT ((0)) NOT NULL,
    [COM_EXPB]     DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_COM_EXPB] DEFAULT ((0)) NOT NULL,
    [COM_EXPC]     DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_COM_EXPC] DEFAULT ((0)) NOT NULL,
    [COM_EXPD]     DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_COM_EXPD] DEFAULT ((0)) NOT NULL,
    [COM_EXTA]     DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_COM_EXTA] DEFAULT ((0)) NOT NULL,
    [COM_EXTB]     DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_COM_EXTB] DEFAULT ((0)) NOT NULL,
    [COM_EXTC]     DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_COM_EXTC] DEFAULT ((0)) NOT NULL,
    [COM_EXTD]     DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_COM_EXTD] DEFAULT ((0)) NOT NULL,
    [EXP_AMT]      DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_EXP_AMT] DEFAULT ((0)) NOT NULL,
    [EXT_AMT]      DECIMAL (14, 4) CONSTRAINT [DF_INSGRLV_EXT_AMT] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_INSGRLV_1] PRIMARY KEY CLUSTERED ([PLAN_NO] ASC)
);

