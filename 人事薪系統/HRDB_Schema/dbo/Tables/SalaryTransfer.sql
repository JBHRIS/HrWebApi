CREATE TABLE [dbo].[SalaryTransfer] (
    [AUTO]         INT           IDENTITY (1, 1) NOT NULL,
    [BANKCODE]     NVARCHAR (50) NOT NULL,
    [CLASSIFY]     NVARCHAR (50) NOT NULL,
    [NO]           INT           NOT NULL,
    [CODE]         NVARCHAR (50) NOT NULL,
    [NAME]         NVARCHAR (50) NOT NULL,
    [LOCATION]     INT           NOT NULL,
    [LENGTH]       INT           NOT NULL,
    [TYPE]         NVARCHAR (50) NOT NULL,
    [SIDE]         NVARCHAR (50) NOT NULL,
    [FILLED]       CHAR (1)      NOT NULL,
    [YEARTYPE]     NVARCHAR (50) NULL,
    [DATEFORMAT]   NVARCHAR (50) NULL,
    [FIXEDCONTENT] NVARCHAR (50) NULL,
    [KEY_MAN]      NVARCHAR (50) NULL,
    [KEY_DATE]     DATETIME      NULL,
    CONSTRAINT [PK_SalaryTransfer] PRIMARY KEY CLUSTERED ([AUTO] ASC)
);

