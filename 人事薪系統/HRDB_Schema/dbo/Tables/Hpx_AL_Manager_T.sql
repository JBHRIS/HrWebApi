CREATE TABLE [dbo].[Hpx_AL_Manager_T] (
    [COMPANY_CODE]     VARCHAR (10)   NOT NULL,
    [EMPLOYEE_NO]      VARCHAR (20)   NOT NULL,
    [PERIOD_FROM]      VARCHAR (15)   NOT NULL,
    [PERIOD_TO]        VARCHAR (15)   NULL,
    [MEMO]             NVARCHAR (500) NULL,
    [LAST_UPDATE_DATE] DATETIME       DEFAULT (getdate()) NULL
);

