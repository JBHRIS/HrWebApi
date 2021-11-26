CREATE TABLE [dbo].[ATTEND_ABNORMAL] (
    [ID]                   INT             IDENTITY (1, 1) NOT NULL,
    [NOBR]                 NVARCHAR (50)   NOT NULL,
    [ADATE]                DATETIME        NOT NULL,
    [TYPE]                 NVARCHAR (50)   NOT NULL,
    [IS_ERROR]             BIT             NOT NULL,
    [ERROR_MINS]           DECIMAL (16, 2) NOT NULL,
    [ON_TIME]              NVARCHAR (50)   NOT NULL,
    [OFF_TIME]             NVARCHAR (50)   NOT NULL,
    [ON_TIME_ACTUAL]       NVARCHAR (50)   NOT NULL,
    [OFF_TIME_ACTUAL]      NVARCHAR (50)   NOT NULL,
    [ON_TIEM_BUFFER_MINS]  DECIMAL (16, 2) NOT NULL,
    [OFF_TIME_BUFFER_MINS] DECIMAL (16, 2) NOT NULL,
    [ROTE_CODE]            NVARCHAR (50)   NOT NULL,
    [CREATE_DATE]          DATETIME        NULL,
    [CREATE_MAN]           NVARCHAR (50)   NULL,
    [UPDATE_DATE]          DATETIME        NULL,
    [UPDATE_MAN]           NVARCHAR (50)   NULL,
    CONSTRAINT [PK_ATTEND_ABNORMAL] PRIMARY KEY CLUSTERED ([NOBR] ASC, [ADATE] ASC, [TYPE] ASC)
);

