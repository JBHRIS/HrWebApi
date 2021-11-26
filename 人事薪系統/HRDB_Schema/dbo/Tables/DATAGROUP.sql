﻿CREATE TABLE [dbo].[DATAGROUP] (
    [DATAGROUP] NVARCHAR (50)  NOT NULL,
    [GROUPNAME] NVARCHAR (50)  NOT NULL,
    [NOTE]      NVARCHAR (500) NOT NULL,
    [KEY_DATE]  DATETIME       NOT NULL,
    [KEY_MAN]   NVARCHAR (50)  NOT NULL,
    [FLOW_GO]   NVARCHAR (50)  NULL,
    [EMAIL]     NVARCHAR (50)  NULL,
    [NOBR]      NVARCHAR (50)  NULL,
    [NOBR_B1]   NVARCHAR (50)  NULL,
    [NOBR_B2]   NVARCHAR (50)  NULL,
    [NOBR_E1]   NVARCHAR (50)  NULL,
    [NOBR_E2]   NVARCHAR (50)  NULL,
    [COMP]      NVARCHAR (50)  NULL,
    CONSTRAINT [PK_DATAGROUP] PRIMARY KEY CLUSTERED ([DATAGROUP] ASC)
);

