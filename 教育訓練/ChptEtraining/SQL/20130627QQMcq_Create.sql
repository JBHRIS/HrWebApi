USE [NYLOKHR_eTraining]
GO

/****** Object:  Table [dbo].[QQMcq]    Script Date: 2013/6/27 上午 10:11:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QQMcq](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsValueInt] [bit] NOT NULL,
 CONSTRAINT [PK_QQMcq] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QQMcq] ADD  CONSTRAINT [DF_QQMcq_IsValueInt]  DEFAULT ((1)) FOR [IsValueInt]
GO

