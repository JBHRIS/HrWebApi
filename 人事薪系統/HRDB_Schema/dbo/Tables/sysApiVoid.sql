CREATE TABLE [dbo].[sysApiVoid] (
    [Code]      NVARCHAR (50)  NOT NULL,
    [Name]      NVARCHAR (500) NULL,
    [RoutePath] NVARCHAR (500) NULL,
    CONSTRAINT [PK_sysApiVoid] PRIMARY KEY CLUSTERED ([Code] ASC)
);

