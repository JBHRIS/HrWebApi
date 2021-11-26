﻿CREATE TABLE [dbo].[INSGRP] (
    [NOBR]     NVARCHAR (50)   NOT NULL,
    [FA_IDNO]  NVARCHAR (50)   NOT NULL,
    [IN_DATE]  DATETIME        NOT NULL,
    [OUT_DATE] DATETIME        NOT NULL,
    [CODE]     NVARCHAR (50)   NOT NULL,
    [AMT1]     DECIMAL (16, 2) NOT NULL,
    [EXP1]     DECIMAL (16, 2) NOT NULL,
    [COP1]     DECIMAL (16, 2) NOT NULL,
    [AMT2]     DECIMAL (16, 2) NOT NULL,
    [EXP2]     DECIMAL (16, 2) NOT NULL,
    [COP2]     DECIMAL (16, 2) NOT NULL,
    [AMT3]     DECIMAL (16, 2) NOT NULL,
    [EXP3]     DECIMAL (16, 2) NOT NULL,
    [COP3]     DECIMAL (16, 2) NOT NULL,
    [AMT4]     DECIMAL (16, 2) NOT NULL,
    [EXP4]     DECIMAL (16, 2) NOT NULL,
    [COP4]     DECIMAL (16, 2) NOT NULL,
    [AMT5]     DECIMAL (16, 2) NOT NULL,
    [EXP5]     DECIMAL (16, 2) NOT NULL,
    [COP5]     DECIMAL (16, 2) NOT NULL,
    [KEY_MAN]  NVARCHAR (50)   NOT NULL,
    [KEY_DATE] DATETIME        NOT NULL,
    [AMT6]     DECIMAL (16, 2) NOT NULL,
    [TOTEXP]   DECIMAL (16, 2) NOT NULL,
    [COPEXP]   DECIMAL (16, 2) CONSTRAINT [DF_INSGRP_COPEXP] DEFAULT ((0)) NOT NULL,
    [SEQ]      NVARCHAR (50)   NOT NULL,
    [EXP3CAL]  BIT             NOT NULL,
    [EXP1CAL]  BIT             NOT NULL,
    [EXP2CAL]  BIT             NOT NULL,
    [GRP_TYPE] NVARCHAR (50)   CONSTRAINT [DF_INSGRP_GRP_TYPE] DEFAULT ('') NOT NULL,
    [PAN]      NVARCHAR (50)   CONSTRAINT [DF_INSGRP_PAN] DEFAULT ('') NOT NULL,
    [EXP6]     DECIMAL (16, 2) NULL,
    [COP6]     DECIMAL (16, 2) NULL,
    CONSTRAINT [PK_INSGRP] PRIMARY KEY CLUSTERED ([NOBR] ASC, [FA_IDNO] ASC, [IN_DATE] ASC, [OUT_DATE] ASC)
);

