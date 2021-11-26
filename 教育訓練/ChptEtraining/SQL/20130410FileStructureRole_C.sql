USE [NYLOKHR_eTraining]
GO

/****** Object:  Table [dbo].[FileStructureRole]    Script Date: 2013/4/10 下午 01:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FileStructureRole](
	[AutoKey] [int] IDENTITY(1,1) NOT NULL,
	[FileStructureKey] [nvarchar](50) NOT NULL,
	[RoleKey] [int] NOT NULL,
 CONSTRAINT [PK_FileStructureRole] PRIMARY KEY CLUSTERED 
(
	[AutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

