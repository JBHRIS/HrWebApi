USE [CHPTHR]
GO

/****** Object:  Table [dbo].[QAMaster]    Script Date: 2014/3/10 下午 01:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QAMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QA_PublishedID] [int] NOT NULL,
	[Nobr] [nvarchar](50) NULL,
	[sysRole] [int] NULL,
	[FillerCategory] [nvarchar](50) NOT NULL,
	[DeptCode] [nvarchar](50) NULL,
	[WriteDate] [datetime] NULL,
	[FillFormDatetimeB] [datetime] NULL,
	[FillFormDatetimeE] [datetime] NULL,
	[TotalScore] [int] NULL,
	[FillInBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_QAMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

