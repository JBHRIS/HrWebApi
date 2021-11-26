CREATE TABLE [dbo].[YEAR_HOLIDAY] (
    [NOBR]        NVARCHAR (50)   NOT NULL,
    [DEPT]        NVARCHAR (50)   NOT NULL,
    [INDT]        DATETIME        NOT NULL,
    [YEARS]       NVARCHAR (50)   NOT NULL,
    [STOP_DATE]   DATETIME        NULL,
    [BACK_DATE]   DATETIME        NULL,
    [ADATE]       DATETIME        NOT NULL,
    [DDATE]       DATETIME        NOT NULL,
    [STOP_TIMES]  INT             NOT NULL,
    [STOP_YEARS]  DECIMAL (16, 2) NOT NULL,
    [TOTAL_YEARS] DECIMAL (16, 2) NOT NULL,
    [GET_DAYS]    DECIMAL (16, 2) NOT NULL,
    [UNIT]        NVARCHAR (50)   NOT NULL,
    [SYSCREAT]    BIT             NOT NULL,
    [KEY_DATE]    DATETIME        NOT NULL,
    [KEY_MAN]     NVARCHAR (50)   NOT NULL,
    [NTRANS]      BIT             NOT NULL,
    [PTRANS]      BIT             NOT NULL,
    [NOTE]        NVARCHAR (50)   NULL,
    [NOTE1]       NVARCHAR (50)   NULL,
    [NOTE2]       NVARCHAR (50)   NULL,
    [NOTE3]       NVARCHAR (50)   NULL,
    [NOTE4]       NVARCHAR (50)   NULL,
    [NOTE5]       NVARCHAR (50)   NULL,
    [Auto]        INT             IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_YEAR_HOLIDAY] PRIMARY KEY CLUSTERED ([Auto] ASC)
);



