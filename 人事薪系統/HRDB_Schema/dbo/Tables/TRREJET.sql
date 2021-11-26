﻿CREATE TABLE [dbo].[TRREJET] (
    [IDNO]     NVARCHAR (50) NOT NULL,
    [YYMM]     NVARCHAR (50) NOT NULL,
    [SER]      NVARCHAR (50) NOT NULL,
    [COSCODE]  NVARCHAR (50) NOT NULL,
    [REJCD]    NVARCHAR (50) NOT NULL,
    [REJ_DATE] DATETIME      NOT NULL,
    [KEY_MAN]  NVARCHAR (50) NOT NULL,
    [KEY_DATE] DATETIME      NOT NULL,
    [SEND]     BIT           NOT NULL
);

