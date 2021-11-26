﻿CREATE TABLE [dbo].[INSLAB] (
    [NOBR]       NVARCHAR (50)   NOT NULL,
    [FA_IDNO]    NVARCHAR (50)   NOT NULL,
    [CODE]       NVARCHAR (50)   NOT NULL,
    [IN_DATE]    DATETIME        NOT NULL,
    [OUT_DATE]   DATETIME        NOT NULL,
    [LRATE_CODE] NVARCHAR (50)   NOT NULL,
    [HRATE_CODE] NVARCHAR (50)   NOT NULL,
    [L_AMT]      DECIMAL (16, 2) NOT NULL,
    [H_AMT]      DECIMAL (16, 2) NOT NULL,
    [KEY_MAN]    NVARCHAR (50)   CONSTRAINT [DF_INSLAB_KEY_MAN] DEFAULT ('') NOT NULL,
    [KEY_DATE]   DATETIME        CONSTRAINT [DF_INSLAB_KEY_DATE] DEFAULT (getdate()) NOT NULL,
    [SEQ]        NVARCHAR (50)   CONSTRAINT [DF_INSLAB_SEQ] DEFAULT ('') NOT NULL,
    [CODE1]      NVARCHAR (50)   CONSTRAINT [DF_INSLAB_CODE1] DEFAULT ('') NOT NULL,
    [NOTE]       NVARCHAR (50)   CONSTRAINT [DF_INSLAB_NOTE] DEFAULT ('') NOT NULL,
    [S_NO]       NVARCHAR (50)   CONSTRAINT [DF_INSLAB_S_NO] DEFAULT ('') NOT NULL,
    [R_AMT]      DECIMAL (16, 2) CONSTRAINT [DF_INSLAB_R_AMT] DEFAULT ((0)) NOT NULL,
    [SPTYP]      NVARCHAR (50)   CONSTRAINT [DF_INSLAB_SPTYP] DEFAULT ('') NOT NULL,
    [WBSPTYP]    NVARCHAR (50)   CONSTRAINT [DF_INSLAB_WBSPTYP] DEFAULT ('') NOT NULL,
    [ROUT_DATE]  DATETIME        CONSTRAINT [DF_INSLAB_ROUT_DATE] DEFAULT (getdate()) NULL,
    [NOSUP]      BIT             CONSTRAINT [DF_INSLAB_NOSUP] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_INSLAB_1] PRIMARY KEY CLUSTERED ([NOBR] ASC, [FA_IDNO] ASC, [IN_DATE] ASC)
);



