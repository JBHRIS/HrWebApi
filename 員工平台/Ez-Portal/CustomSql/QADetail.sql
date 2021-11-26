USE [CHPTHR]
GO

/****** Object:  Table [dbo].[QADetail]    Script Date: 2014/3/10 下午 01:26:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QADetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QAMasterId] [int] NOT NULL,
	[QQItemId] [int] NOT NULL,
	[McqIntValue] [int] NULL,
	[McqStringValue] [nvarchar](50) NULL,
	[TfqValue] [bit] NULL,
	[SaqValue] [nvarchar](2000) NULL,
 CONSTRAINT [PK_QADetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

