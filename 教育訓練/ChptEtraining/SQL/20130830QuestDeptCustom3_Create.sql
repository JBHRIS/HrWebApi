USE [CHPT_eTraining]
GO

/****** Object:  Table [dbo].[QuestDeptCustom3]    Script Date: 08/30/2013 04:36:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QuestDeptCustom3](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[DeptCode] [nvarchar](50) NOT NULL,
	[TrainingMethodCode] [nvarchar](50) NULL,
	[Amt] [int] NULL,
	[StudentNum] [int] NULL,
	[Month] [int] NULL,
	[Minutes] [int] NULL,
	[IsRejection] [bit] NOT NULL,
	[Rejecter] [nvarchar](50) NULL,
	[DeptReject] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuestDeptCustom3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QuestDeptCustom3] ADD  CONSTRAINT [DF_QuestDeptCustom3_IsRejection]  DEFAULT ((0)) FOR [IsRejection]
GO

