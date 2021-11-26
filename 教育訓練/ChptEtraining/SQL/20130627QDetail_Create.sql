USE [NYLOKHR_eTraining]
GO

/****** Object:  Table [dbo].[QDetail]    Script Date: 2013/6/27 上午 10:11:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QTplCategoryId] [int] NOT NULL,
	[QQItemId] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[IsRequired] [bit] NOT NULL,
 CONSTRAINT [PK_QDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QDetail] ADD  CONSTRAINT [DF_QDetail_IsRequired]  DEFAULT ((0)) FOR [IsRequired]
GO

