CREATE TABLE [dbo].[NewsBrowsing] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [news_id]      NVARCHAR (50) NOT NULL,
    [Nobr]         NVARCHAR (50) NOT NULL,
    [BrowsingTime] DATETIME      NULL,
    CONSTRAINT [PK_NewsBrowsing] PRIMARY KEY CLUSTERED ([Id] ASC)
);

