CREATE TABLE [dbo].[sysLoginTime] (
    [iAutoKey]             INT           IDENTITY (1, 1) NOT NULL,
    [sysLoginUser_sUserID] NVARCHAR (50) NOT NULL,
    [sLoginIP]             NVARCHAR (50) NOT NULL,
    [bLoginSuccess]        BIT           NOT NULL,
    [sSessionid]           NVARCHAR (50) NOT NULL,
    [dLoginTime]           DATETIME      NULL,
    [dLogoutTime]          DATETIME      NULL,
    CONSTRAINT [PK_sysLoginTime] PRIMARY KEY CLUSTERED ([iAutoKey] ASC)
);

