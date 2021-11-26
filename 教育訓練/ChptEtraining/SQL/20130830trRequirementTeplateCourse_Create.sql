USE [CHPT_eTraining]
GO

/****** Object:  Table [dbo].[trRequirementTemplateCourse]    Script Date: 08/30/2013 04:39:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[trRequirementTemplateCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RT_Code] [nvarchar](50) NOT NULL,
	[CourseCode] [nvarchar](50) NOT NULL,
	[Sequence] [int] NOT NULL,
 CONSTRAINT [PK_trRequirementTemplateCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[trRequirementTemplateCourse] ADD  CONSTRAINT [DF_trRequirementTemplateCourse_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO

