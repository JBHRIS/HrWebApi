USE [Formosa_eLearning]
GO

/****** Object:  Table [dbo].[ClassTeacher]    Script Date: 05/09/2012 08:48:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClassTeacher](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[iClassAutoKey] [int] NOT NULL,
	[sTeacherCode] [nvarchar](50) NOT NULL,
	[Charge] [int] NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
	[Minutes] [int] NULL,
 CONSTRAINT [PK_ClassTeacher] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

