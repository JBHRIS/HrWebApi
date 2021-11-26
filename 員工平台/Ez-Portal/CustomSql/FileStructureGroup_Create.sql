USE [CHPTHR]
GO

/****** Object:  Table [dbo].[FileStructureGroup]    Script Date: 2013/8/27 下午 05:38:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FileStructureGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[FileStructureCode] [nvarchar](200) NOT NULL,
	[Sequence] [int] NOT NULL,
 CONSTRAINT [PK_FileStructureGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FileStructureGroup] ADD  CONSTRAINT [DF_FileStructureGroup_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO

