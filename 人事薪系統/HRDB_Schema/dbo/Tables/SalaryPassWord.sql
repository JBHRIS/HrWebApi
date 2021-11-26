CREATE TABLE [dbo].[SalaryPassWord] (
    [iAutoKey]   INT            IDENTITY (1, 1) NOT NULL,
    [sNobr]      NVARCHAR (50)  NOT NULL,
    [sPassWord]  NVARCHAR (200) NOT NULL,
    [sIP]        NVARCHAR (50)  NULL,
    [dKeyDate]   DATETIME       NULL,
    [dLoginDate] DATETIME       NULL,
    [sLoginIP]   NVARCHAR (50)  NULL,
    CONSTRAINT [PK_SalaryPassWord] PRIMARY KEY CLUSTERED ([iAutoKey] ASC)
);

