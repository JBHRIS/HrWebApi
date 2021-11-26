USE [NYLOKHR_eTraining]
GO

/****** Object:  Table [dbo].[QAMaster]    Script Date: 07/02/2013 23:28:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QAMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassAutoKey] [int] NOT NULL,
	[QTplCode] [nvarchar](50) NOT NULL,
	[Nobr] [nvarchar](50) NULL,
	[sysRole] [int] NULL,
	[TeacherCode] [nvarchar](50) NULL,
	[FillerCategory] [nvarchar](50) NOT NULL,
	[DeptCode] [nvarchar](50) NULL,
	[WriteDate] [datetime] NULL,
	[FillFormDatetimeB] [datetime] NULL,
	[FillFormDatetimeE] [datetime] NULL,
	[TeacherCheckedDate] [datetime] NULL,
	[TRCheckedDate] [datetime] NULL,
	[TotalScore] [int] NULL,
 CONSTRAINT [PK_QAMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

