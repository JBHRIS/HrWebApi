CREATE TABLE [dbo].[Hpx_AL_T] (
    [COMPANY_CODE]     VARCHAR (10)   NOT NULL,
    [PERIOD_NAME]      VARCHAR (15)   NOT NULL,
    [EMPLOYEE_NO]      VARCHAR (20)   NOT NULL,
    [DATE_T]           VARCHAR (10)   NOT NULL,
    [AL_HR]            FLOAT (53)     NULL,
    [USE_HR]           FLOAT (53)     NULL,
    [MEMO]             NVARCHAR (500) NULL,
    [STATUS]           VARCHAR (50)   NULL,
    [LAST_UPDATE_DATE] DATETIME       CONSTRAINT [DF_Hpx_AL_T_LAST_UPDATE_DATE] DEFAULT (getdate()) NULL,
    [COST_CODE]        VARCHAR (10)   NULL
);

