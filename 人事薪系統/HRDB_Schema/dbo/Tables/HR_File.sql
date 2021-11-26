CREATE TABLE [dbo].[HR_File] (
    [ID]           NVARCHAR (50)   NOT NULL,
    [GroupID]      NVARCHAR (50)   NOT NULL,
    [FileBinary]   VARBINARY (MAX) NULL,
    [IsStoredInDB] BIT             CONSTRAINT [DF_HR_File_IsStoredInDB] DEFAULT ((1)) NOT NULL,
    [FileName]     NVARCHAR (1000) NOT NULL,
    [Path]         NVARCHAR (1000) NULL,
    [FileType]     NVARCHAR (200)  NULL,
    [FileSize]     INT             NULL,
    [FileDesc]     NVARCHAR (500)  NULL,
    [FileNameExt]  NVARCHAR (10)   NULL,
    [CreatedDate]  DATETIME        NULL,
    [CreatedBy]    NVARCHAR (50)   NULL,
    CONSTRAINT [PK_HR_File] PRIMARY KEY CLUSTERED ([ID] ASC)
);

