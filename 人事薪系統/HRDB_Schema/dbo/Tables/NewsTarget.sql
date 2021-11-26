CREATE TABLE [dbo].[NewsTarget] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [news_id]  NVARCHAR (50) NOT NULL,
    [EmpNo]    NVARCHAR (50) NULL,
    [DetpCode] NVARCHAR (50) NULL,
    CONSTRAINT [PK_NewsTarget] PRIMARY KEY CLUSTERED ([Id] ASC)
);

