CREATE TABLE [dbo].[sysApiVoidBlackList] (
    [AutoKey]     INT            IDENTITY (1, 1) NOT NULL,
    [Nobr]        NVARCHAR (50)  NOT NULL,
    [ApiVoidCode] NVARCHAR (200) NOT NULL,
    [KeyDate]     DATETIME       NOT NULL,
    [KeyMan]      NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_sysApiVoidBlackList] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

