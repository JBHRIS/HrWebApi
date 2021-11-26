USE [NYLOKHR_eTraining]
GO

/****** Object:  Table [dbo].[QTpl]    Script Date: 2013/6/27 上午 10:09:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QTpl](
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FillerCategory] [nvarchar](10) NOT NULL,
	[IsTeacherGrade] [bit] NOT NULL,
	[FillFormSpan] [int] NOT NULL,
	[KeyMan] [nvarchar](50) NULL,
	[KeyDate] [datetime] NULL,
	[BeenUsed] [bit] NOT NULL,
 CONSTRAINT [PK_QTpl] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QTpl] ADD  CONSTRAINT [DF_QTpl_IsBeenUsed]  DEFAULT ((0)) FOR [BeenUsed]
GO

