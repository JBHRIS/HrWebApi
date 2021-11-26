CREATE TABLE [dbo].[FileStructureRole] (
    [AutoKey]          INT            IDENTITY (1, 1) NOT NULL,
    [FileStructureKey] NVARCHAR (200) NOT NULL,
    [RoleCode]         NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_FileStructureRole] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

