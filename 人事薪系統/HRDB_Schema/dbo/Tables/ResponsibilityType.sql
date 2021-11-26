CREATE TABLE [dbo].[ResponsibilityType] (
    [ResponsibilityCode] NVARCHAR (50) NOT NULL,
    [ResponsibilityName] NVARCHAR (50) NOT NULL,
    [KeyDate]            DATETIME      NOT NULL,
    [KeyMan]             NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ResponsibilityType] PRIMARY KEY CLUSTERED ([ResponsibilityCode] ASC)
);

