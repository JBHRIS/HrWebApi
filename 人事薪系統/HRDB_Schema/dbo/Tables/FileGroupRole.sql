CREATE TABLE [dbo].[FileGroupRole] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [FileGroupId] INT           NOT NULL,
    [Role]        NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_FileGroupRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

