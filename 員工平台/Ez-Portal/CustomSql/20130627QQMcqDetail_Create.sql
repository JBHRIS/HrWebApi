

/****** Object:  Table [dbo].[QQMcqDetail]    Script Date: 2013/6/27 上午 10:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QQMcqDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QQMcqId] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[StringValue] [nvarchar](50) NULL,
	[IntValue] [int] NULL,
 CONSTRAINT [PK_QQMcqDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QQMcqDetail] ADD  CONSTRAINT [DF_QQMcqDetail_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO

