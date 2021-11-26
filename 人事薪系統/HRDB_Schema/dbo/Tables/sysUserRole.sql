CREATE TABLE [dbo].[sysUserRole] (
    [iAutoKey] INT           IDENTITY (1, 1) NOT NULL,
    [NOBR]     NVARCHAR (50) NOT NULL,
    [RoleCode] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_sysUserRole] PRIMARY KEY CLUSTERED ([iAutoKey] ASC)
);

