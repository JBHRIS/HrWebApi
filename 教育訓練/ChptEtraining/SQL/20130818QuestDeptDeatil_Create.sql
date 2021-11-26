USE [JB_eTraining]
GO

/****** Object:  Table [dbo].[QuestDeptDetail]    Script Date: 08/19/2013 00:39:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QuestDeptDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestDeptId] [int] NOT NULL,
	[trRequirementTemplateDetailId] [int] NOT NULL,
	[DemandIntensity] [int] NULL,
 CONSTRAINT [PK_QuestDeptDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

