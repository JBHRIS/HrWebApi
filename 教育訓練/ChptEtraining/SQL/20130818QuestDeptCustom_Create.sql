USE [JB_eTraining]
GO

/****** Object:  Table [dbo].[QuestDeptCustom]    Script Date: 08/19/2013 01:05:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QuestDeptCustom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[CourseName] [nvarchar](200) NOT NULL,
	[DeptCode] [nvarchar](50) NOT NULL,
	[DemandIntensity] [int] NULL,
 CONSTRAINT [PK_QuestDeptCustom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

