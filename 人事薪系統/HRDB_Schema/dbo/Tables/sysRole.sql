CREATE TABLE [dbo].[sysRole] (
    [Code]        NVARCHAR (50) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [IsAdminRole] BIT           CONSTRAINT [DF_sysRole_IsAdminRole] DEFAULT ((0)) NOT NULL,
    [IsVisible]   BIT           CONSTRAINT [DF_sysRole_IsVisible] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_sysRole] PRIMARY KEY CLUSTERED ([Code] ASC)
);

