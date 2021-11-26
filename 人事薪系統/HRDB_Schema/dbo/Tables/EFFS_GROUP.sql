CREATE TABLE [dbo].[EFFS_GROUP] (
    [effsgroupID]   NVARCHAR (50) NOT NULL,
    [effsgroupname] NVARCHAR (50) NULL,
    [effsgroup]     NVARCHAR (50) NULL,
    [ismangRate]    BIT           NULL,
    [order]         INT           NULL,
    [type]          NVARCHAR (50) NULL,
    CONSTRAINT [PK_EFFS_GROUP] PRIMARY KEY CLUSTERED ([effsgroupID] ASC)
);

