CREATE TABLE [dbo].[sysMoudleByApiVoid] (
    [MoudleId]   NVARCHAR (50)  NOT NULL,
    [ApiId]      NVARCHAR (50)  NOT NULL,
    [KeyMan]     NVARCHAR (50)  NOT NULL,
    [UpdateDate] DATETIME       NOT NULL,
    [Note]       NVARCHAR (200) NULL,
    CONSTRAINT [PK_MoudleByApi] PRIMARY KEY CLUSTERED ([MoudleId] ASC, [ApiId] ASC)
);

