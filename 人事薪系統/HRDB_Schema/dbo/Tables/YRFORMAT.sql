﻿CREATE TABLE [dbo].[YRFORMAT] (
    [M_FORMAT]   NVARCHAR (50)   NOT NULL,
    [M_FMT_NAME] NVARCHAR (50)   NOT NULL,
    [KEY_MAN]    NVARCHAR (50)   NOT NULL,
    [KEY_DATE]   DATETIME        NOT NULL,
    [FIXRATE]    DECIMAL (14, 4) NOT NULL,
    [SUPPLEMIN]  DECIMAL (14, 4) NOT NULL,
    [SUPPLEMAX]  DECIMAL (14, 4) NOT NULL,
    [INCOMETYPE] NVARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_YRFORMAT] PRIMARY KEY CLUSTERED ([M_FORMAT] ASC)
);

