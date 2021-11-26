CREATE TABLE [dbo].[ABS_EXT] (
    [NOBR]       NVARCHAR (50)   NOT NULL,
    [NAME]       NVARCHAR (50)   NULL,
    [DEPT]       NVARCHAR (50)   NULL,
    [HCODE]      NVARCHAR (50)   NOT NULL,
    [H_NAME]     NVARCHAR (50)   NULL,
    [ADATE]      DATETIME        NOT NULL,
    [DDATE]      DATETIME        NOT NULL,
    [TOL_HOURS]  DECIMAL (16, 2) NOT NULL,
    [EXT_HOURS]  DECIMAL (16, 2) NOT NULL,
    [CASH_HOURS] DECIMAL (16, 2) NOT NULL,
    [AMT]        DECIMAL (16, 2) NOT NULL,
    [KEY_DATE]   DATETIME        NOT NULL,
    [KEY_MAN]    NVARCHAR (50)   NOT NULL,
    [NOTE]       NVARCHAR (500)  NOT NULL,
    [SNO]        INT             IDENTITY (1, 1) NOT NULL,
    [SYSCREAT]   BIT             NOT NULL,
    [NTRANS]     BIT             NOT NULL,
    [PTRANS]     BIT             NOT NULL,
    [YYMM]       NVARCHAR (50)   NOT NULL,
    [SEQ]        NVARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_ABS_EXT] PRIMARY KEY CLUSTERED ([NOBR] ASC, [ADATE] ASC, [HCODE] ASC)
);

