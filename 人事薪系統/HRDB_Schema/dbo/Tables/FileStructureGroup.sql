CREATE TABLE [dbo].[FileStructureGroup] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [GroupId]           INT            NOT NULL,
    [FileStructureCode] NVARCHAR (200) NOT NULL,
    [Sequence]          INT            CONSTRAINT [DF_FileStructureGroup_Sequence] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_FileStructureGroup] PRIMARY KEY CLUSTERED ([Id] ASC)
);

