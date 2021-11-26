USE [NYLOKHR_eTraining]
GO

/****** Object:  Table [dbo].[QQItem]    Script Date: 2013/6/27 上午 10:10:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QQItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](1000) NOT NULL,
	[TypeCode] [nvarchar](50) NOT NULL,
	[McqId] [int] NULL,
	[McqDisplayHorizontal] [bit] NOT NULL,
 CONSTRAINT [PK_QQItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QQItem] ADD  CONSTRAINT [DF_QQItem_McqDisplayHorizontal]  DEFAULT ((1)) FOR [McqDisplayHorizontal]
GO

