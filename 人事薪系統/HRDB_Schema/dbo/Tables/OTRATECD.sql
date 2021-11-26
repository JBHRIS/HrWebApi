﻿CREATE TABLE [dbo].[OTRATECD] (
    [OTRATE_CODE]      NVARCHAR (50)   NOT NULL,
    [OTRATE_NAME]      NVARCHAR (50)   NOT NULL,
    [OTRATE_TYPEW]     NVARCHAR (50)   NOT NULL,
    [OT133WTIME_B]     DECIMAL (16, 2) NOT NULL,
    [OT133WTIME_E]     DECIMAL (16, 2) NOT NULL,
    [OT133WRATE]       DECIMAL (16, 4) NOT NULL,
    [OT133WAMT]        DECIMAL (16, 2) NOT NULL,
    [OT167WTIME_B]     DECIMAL (16, 2) NOT NULL,
    [OT167WTIME_E]     DECIMAL (16, 2) NOT NULL,
    [OT167WRATE]       DECIMAL (16, 4) NOT NULL,
    [OT167WAMT]        DECIMAL (16, 2) NOT NULL,
    [OT200WTIME_B]     DECIMAL (16, 2) NOT NULL,
    [OT200WTIME_E]     DECIMAL (16, 2) NOT NULL,
    [OT200WRATE]       DECIMAL (16, 4) NOT NULL,
    [OT200WAMT]        DECIMAL (16, 2) NOT NULL,
    [OT200HRATE]       DECIMAL (16, 4) NOT NULL,
    [OT200HAMT]        DECIMAL (16, 2) NOT NULL,
    [OTRATE_TYPEH]     NVARCHAR (1)    NOT NULL,
    [KEY_MAN]          NVARCHAR (8)    NOT NULL,
    [KEY_DATE]         DATETIME        NOT NULL,
    [MIN_HOURS]        DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_MIN_HOURS] DEFAULT ((0)) NOT NULL,
    [OT133HTIME_B]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT133HTIME_B] DEFAULT ((0)) NOT NULL,
    [OT133HTIME_E]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT133HTIME_E] DEFAULT ((0)) NOT NULL,
    [OT133HRATE]       DECIMAL (16, 4) CONSTRAINT [DF_OTRATECD_OT133HRATE] DEFAULT ((0)) NOT NULL,
    [OT133HAMT]        DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT133HAMT] DEFAULT ((0)) NOT NULL,
    [OT167HTIME_B]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT167HTIME_B] DEFAULT ((0)) NOT NULL,
    [OT167HTIME_E]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT167HTIME_E] DEFAULT ((0)) NOT NULL,
    [OT167HRATE]       DECIMAL (16, 4) CONSTRAINT [DF_OTRATECD_OT167HRATE] DEFAULT ((0)) NOT NULL,
    [OT167HAMT]        DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT167HAMT] DEFAULT ((0)) NOT NULL,
    [OT200HTIME_B]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT200HTIME_B] DEFAULT ((0)) NOT NULL,
    [OT200HTIME_E]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT200HTIME_E] DEFAULT ((0)) NOT NULL,
    [FIXPER]           BIT             CONSTRAINT [DF_OTRATECD_FIXPER] DEFAULT ((0)) NOT NULL,
    [OTUNIT]           INT             CONSTRAINT [DF_OTRATECD_OTUNIT] DEFAULT ((0)) NOT NULL,
    [OTRATE_TYPEN]     NVARCHAR (50)   DEFAULT ('') NOT NULL,
    [OT133NTIME_B]     DECIMAL (16, 2) DEFAULT ((0)) NOT NULL,
    [OT133NTIME_E]     DECIMAL (16, 2) DEFAULT ((0)) NOT NULL,
    [OT133NRATE]       DECIMAL (16, 4) DEFAULT ((0)) NOT NULL,
    [OT133NAMT]        DECIMAL (16, 2) DEFAULT ((0)) NOT NULL,
    [OT167NTIME_B]     DECIMAL (16, 2) DEFAULT ((0)) NOT NULL,
    [OT167NTIME_E]     DECIMAL (16, 2) DEFAULT ((0)) NOT NULL,
    [OT167NRATE]       DECIMAL (16, 4) DEFAULT ((0)) NOT NULL,
    [OT167NAMT]        DECIMAL (16, 2) DEFAULT ((0)) NOT NULL,
    [OT200NTIME_B]     DECIMAL (16, 2) DEFAULT ((0)) NOT NULL,
    [OT200NTIME_E]     DECIMAL (16, 2) DEFAULT ((0)) NOT NULL,
    [OT200NRATE]       DECIMAL (16, 4) DEFAULT ((0)) NOT NULL,
    [OT200NAMT]        DECIMAL (16, 2) DEFAULT ((0)) NOT NULL,
    [OTH_REST_TIME_B1] DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OTH_REST_TIME_B1] DEFAULT ((0)) NOT NULL,
    [OTH_REST_TIME_E1] DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OTH_REST_TIME_E1] DEFAULT ((0)) NOT NULL,
    [OTH_REST_HOURS1]  DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OTH_REST_HOURS1] DEFAULT ((0)) NOT NULL,
    [OTH_NOOT]         BIT             DEFAULT ((0)) NOT NULL,
    [OTH_GETREST]      BIT             DEFAULT ((0)) NOT NULL,
    [OTN_REST_TIME_B1] DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_TIME_B11] DEFAULT ((0)) NOT NULL,
    [OTN_REST_TIME_E1] DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_TIME_E11] DEFAULT ((0)) NOT NULL,
    [OTN_REST_HOURS1]  DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_HOURS11] DEFAULT ((0)) NOT NULL,
    [OTN_GETREST]      BIT             DEFAULT ((0)) NOT NULL,
    [OTRATE_TYPER]     NVARCHAR (50)   CONSTRAINT [DF_OTRATE_TYPER] DEFAULT ('') NOT NULL,
    [OT133RTIME_B]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT133HTIME_B1] DEFAULT ((0)) NOT NULL,
    [OT133RTIME_E]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT133HTIME_E1] DEFAULT ((0)) NOT NULL,
    [OT133RRATE]       DECIMAL (16, 4) CONSTRAINT [DF_OTRATECD_OT133HRATE1] DEFAULT ((0)) NOT NULL,
    [OT133RAMT]        DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT133HAMT1] DEFAULT ((0)) NOT NULL,
    [OT167RTIME_B]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT167HTIME_B1] DEFAULT ((0)) NOT NULL,
    [OT167RTIME_E]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT167HTIME_E1] DEFAULT ((0)) NOT NULL,
    [OT167RRATE]       DECIMAL (16, 4) CONSTRAINT [DF_OTRATECD_OT167HRATE1] DEFAULT ((0)) NOT NULL,
    [OT167RAMT]        DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT167HAMT1] DEFAULT ((0)) NOT NULL,
    [OT200RTIME_B]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT200HTIME_B1] DEFAULT ((0)) NOT NULL,
    [OT200RTIME_E]     DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT200HTIME_E1] DEFAULT ((0)) NOT NULL,
    [OT200RRATE]       DECIMAL (16, 4) CONSTRAINT [DF_OTRATECD_OT200RRATE1] DEFAULT ((0)) NOT NULL,
    [OT200RAMT]        DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT200RAMT1] DEFAULT ((0)) NOT NULL,
    [OT_REST_TIME_B1]  DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_TIME_B1] DEFAULT ((0)) NOT NULL,
    [OT_REST_TIME_E1]  DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_TIME_E1] DEFAULT ((0)) NOT NULL,
    [OT_REST_HOURS1]   DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_HOURS1] DEFAULT ((0)) NOT NULL,
    [OT_REST_TIME_B2]  DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_TIME_B2] DEFAULT ((0)) NOT NULL,
    [OT_REST_TIME_E2]  DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_TIME_E2] DEFAULT ((0)) NOT NULL,
    [OT_REST_HOURS2]   DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_HOURS2] DEFAULT ((0)) NOT NULL,
    [OT_REST_TIME_B3]  DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_TIME_B3] DEFAULT ((0)) NOT NULL,
    [OT_REST_TIME_E3]  DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_TIME_E3] DEFAULT ((0)) NOT NULL,
    [OT_REST_HOURS3]   DECIMAL (16, 2) CONSTRAINT [DF_OTRATECD_OT_REST_HOURS3] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_OTRATECD] PRIMARY KEY CLUSTERED ([OTRATE_CODE] ASC)
);







