CREATE TABLE [dbo].[GroupType] (
    [GroupCode] NVARCHAR (50) NOT NULL,
    [GroupName] NVARCHAR (50) NOT NULL,
    [KeyDate]   DATETIME      NOT NULL,
    [KeyMan]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_GroupType] PRIMARY KEY CLUSTERED ([GroupCode] ASC)
);

