USE [NYLOKHR_eTraining]
GO

/****** Object:  Table [dbo].[QTplCategory]    Script Date: 2013/6/27 上午 10:09:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QTplCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QTplCode] [nvarchar](50) NOT NULL,
	[QCategoryCode] [nvarchar](50) NOT NULL,
	[Sequence] [int] NOT NULL,
 CONSTRAINT [PK_QTplCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QTplCategory] ADD  CONSTRAINT [DF_QTplCategory_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO

