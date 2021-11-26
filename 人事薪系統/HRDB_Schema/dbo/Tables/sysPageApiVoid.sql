CREATE TABLE [dbo].[sysPageApiVoid] (
    [AutoKey]     INT            IDENTITY (1, 1) NOT NULL,
    [PageCode]    NVARCHAR (50)  NOT NULL,
    [ApiVoidCode] NVARCHAR (200) NOT NULL,
    [KeyDate]     DATETIME       NOT NULL,
    [KeyName]     NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_sysPageApiVoid] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

