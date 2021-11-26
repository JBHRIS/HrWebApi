﻿CREATE TABLE [dbo].[U_SYS4] (
    [Comp]             NVARCHAR (50)   NOT NULL,
    [LSALCODE]         NVARCHAR (50)   NULL,
    [LABOVERSALCODE]   NVARCHAR (50)   NULL,
    [LABREPAIRSALCODE] NVARCHAR (50)   NULL,
    [LJOBPER]          DECIMAL (16, 3) NULL,
    [LJOBPER1]         DECIMAL (16, 3) NULL,
    [RETIRERATE]       DECIMAL (16, 3) NULL,
    [RETIRERATE1]      DECIMAL (16, 3) NULL,
    [NRETIRERATE]      DECIMAL (16, 3) NULL,
    [NRETIRERATE1]     DECIMAL (16, 3) NULL,
    [RETSALCODE]       NVARCHAR (50)   NULL,
    CONSTRAINT [PK_U_SYS4] PRIMARY KEY CLUSTERED ([Comp] ASC)
);

