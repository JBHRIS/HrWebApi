﻿CREATE TABLE [dbo].[SALENRICH] (
    [AUTOKEY]  INT             IDENTITY (1, 1) NOT NULL,
    [NOBR]     NVARCHAR (50)   NOT NULL,
    [YYMM]     NVARCHAR (50)   NOT NULL,
    [SEQ]      NVARCHAR (50)   NOT NULL,
    [SAL_CODE] NVARCHAR (50)   NOT NULL,
    [AMT]      DECIMAL (16, 2) NOT NULL,
    [KEY_MAN]  NVARCHAR (50)   NOT NULL,
    [KEY_DATE] DATETIME        NOT NULL,
    [MEMO]     NVARCHAR (120)  CONSTRAINT [DF_SALENRICH_MEMO] DEFAULT ('') NOT NULL,
    [FA_IDNO]  NVARCHAR (50)   CONSTRAINT [DF_SALENRICH_FA_IDNO] DEFAULT ('') NOT NULL,
    [IMPORT]   BIT             CONSTRAINT [DF_SALENRICH_IMPORT] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SALENRICH] PRIMARY KEY CLUSTERED ([AUTOKEY] ASC)
);

