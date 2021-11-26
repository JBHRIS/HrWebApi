USE [Formosa_eLearning]
GO

/****** Object:  Table [dbo].[CourseType]    Script Date: 02/20/2012 11:09:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CourseType](
	[sCode] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NOT NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_CourseType] PRIMARY KEY CLUSTERED 
(
	[sCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT CourseType VALUES (N'DEMAND', N'調查', NULL, NULL)
INSERT CourseType VALUES (N'DUTY', N'職能', NULL, NULL)
INSERT CourseType VALUES (N'OTHERS', N'其他', NULL, NULL)
INSERT CourseType VALUES (N'POLICY', N'政策', NULL, NULL)
GO

