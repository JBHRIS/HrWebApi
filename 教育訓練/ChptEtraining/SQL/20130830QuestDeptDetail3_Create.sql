USE [CHPT_eTraining]
GO

/****** Object:  Table [dbo].[QuestDeptDetail3]    Script Date: 08/30/2013 04:37:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QuestDeptDetail3](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestDeptId] [int] NOT NULL,
	[trRequirementTemplateCourseId] [int] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[TrainingMethodCode] [nvarchar](50) NULL,
	[Amt] [int] NULL,
	[StudentNum] [int] NULL,
	[Month] [int] NULL,
	[Minutes] [int] NULL,
	[IsRejection] [bit] NOT NULL,
	[Rejecter] [nvarchar](50) NULL,
	[DeptReject] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuestDeptDetail3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QuestDeptDetail3] ADD  CONSTRAINT [DF_QuestDeptDetail3_IsRequired]  DEFAULT ((0)) FOR [IsRequired]
GO

ALTER TABLE [dbo].[QuestDeptDetail3] ADD  CONSTRAINT [DF_QuestDeptDetail3_IsRejection]  DEFAULT ((0)) FOR [IsRejection]
GO

