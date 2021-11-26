CREATE TABLE [dbo].[sysDefault] (
    [iAutoKey]  INT            IDENTITY (1, 1) NOT NULL,
    [sName]     NVARCHAR (200) NULL,
    [sCategory] NVARCHAR (50)  NOT NULL,
    [sKey]      NVARCHAR (50)  NOT NULL,
    [sValue]    NVARCHAR (200) NULL,
    [sType]     NVARCHAR (50)  NOT NULL,
    [iOrder]    INT            NOT NULL,
    [sKeyMan]   NVARCHAR (50)  NULL,
    [dKeyDate]  DATETIME       NULL,
    CONSTRAINT [PK_sysDefault] PRIMARY KEY CLUSTERED ([iAutoKey] ASC)
);

