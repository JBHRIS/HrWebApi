

/****** Object:  Table [dbo].[QQMcqDetailTpl]    Script Date: 2013/6/27 上午 10:12:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QQMcqDetailTpl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupCode] [nvarchar](50) NOT NULL,
	[Sequence] [int] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[StringValue] [nvarchar](50) NULL,
	[IntValue] [int] NULL,
 CONSTRAINT [PK_QQMcqDetailTpl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QQMcqDetailTpl] ADD  CONSTRAINT [DF_QQMcqDetailTpl_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO

