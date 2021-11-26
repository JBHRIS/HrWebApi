USE [CHPTHR]
GO

/****** Object:  Table [dbo].[FileStructure]    Script Date: 2013/8/20 上午 09:45:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FileStructure](
	[Code] [nvarchar](200) NOT NULL,
	[sPath] [nvarchar](255) NULL,
	[sFileName] [nvarchar](255) NULL,
	[sFileTitle] [nvarchar](50) NULL,
	[sDescription] [nvarchar](200) NULL,
	[sParentKey] [nvarchar](200) NOT NULL,
	[iOrder] [int] NOT NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
	[sIconPath] [nvarchar](255) NULL,
	[sIconName] [nvarchar](255) NULL,
 CONSTRAINT [PK_FileStructure] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

