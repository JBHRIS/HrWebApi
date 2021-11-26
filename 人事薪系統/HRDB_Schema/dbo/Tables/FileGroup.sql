CREATE TABLE [dbo].[FileGroup] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Sequence] INT           CONSTRAINT [DF_FileGroup_Sequence] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_FileGroup] PRIMARY KEY CLUSTERED ([Id] ASC)
);

