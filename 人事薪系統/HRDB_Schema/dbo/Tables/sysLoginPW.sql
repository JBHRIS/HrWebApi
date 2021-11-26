CREATE TABLE [dbo].[sysLoginPW] (
    [iAutoKey]             INT           IDENTITY (1, 1) NOT NULL,
    [sysLoginUser_sUserID] NVARCHAR (50) NOT NULL,
    [sUserPWold]           NVARCHAR (50) NOT NULL,
    [sUserPWnew]           NVARCHAR (50) NOT NULL,
    [sKeyMan]              NVARCHAR (50) NULL,
    [dKeyDate]             DATETIME      NULL,
    CONSTRAINT [PK_sysLoginPW] PRIMARY KEY CLUSTERED ([iAutoKey] ASC)
);

