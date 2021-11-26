CREATE TABLE [dbo].[sysRolePage] (
    [AutoKey]  INT            IDENTITY (1, 1) NOT NULL,
    [RoleCode] NVARCHAR (50)  NOT NULL,
    [PageCode] NVARCHAR (200) NOT NULL,
    [KEY_DATE] DATETIME       NOT NULL,
    [KEY_MAN]  NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_sysRolePage] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

