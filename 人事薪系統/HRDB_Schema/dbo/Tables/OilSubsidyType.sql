CREATE TABLE [dbo].[OilSubsidyType] (
    [Code]           NVARCHAR (50) NOT NULL,
    [OilSubsidyType] NVARCHAR (50) NOT NULL,
    [KEY_DATE]       DATETIME      NOT NULL,
    [KEY_MAN]        NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OilSubsidyType] PRIMARY KEY CLUSTERED ([Code] ASC)
);

