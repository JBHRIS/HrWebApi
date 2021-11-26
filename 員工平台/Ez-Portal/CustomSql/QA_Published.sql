USE [CHPTHR]
GO

/****** Object:  Table [dbo].[QA_Published]    Script Date: 2014/3/10 下午 01:26:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QA_Published](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QTplCode] [nvarchar](50) NOT NULL,
	[PublishDatetime] [datetime] NOT NULL,
	[FillFormDatetimeB] [datetime] NOT NULL,
	[FillFormDatetimeE] [datetime] NOT NULL,
	[IsPublished] [bit] NOT NULL,
	[WritedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_QA_Published] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QA_Published] ADD  CONSTRAINT [DF_QA_Published_IsPublished]  DEFAULT ((0)) FOR [IsPublished]
GO

