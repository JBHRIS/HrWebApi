USE [JB_eTraining]
GO

/****** Object:  Table [dbo].[QuestDept]    Script Date: 08/18/2013 22:33:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QuestDept](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[DeptCode] [nvarchar](50) NOT NULL,
	[WriteDate] [datetime] NULL,
	[WritedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuestDept] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

