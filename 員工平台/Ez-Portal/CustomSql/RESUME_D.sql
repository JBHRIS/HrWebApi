USE [HOLYHRDB]
GO

/****** Object:  Table [dbo].[RESUME_D]    Script Date: 07/10/2013 23:54:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RESUME_D](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UIDENTID] [nvarchar](50) NULL,
	[SKEYD] [decimal](16, 2) NULL,
	[SER_COMP] [nvarchar](100) NULL,
	[SER_DEPT] [nvarchar](100) NULL,
	[SER_POS] [nvarchar](100) NULL,
	[SER_SDA] [nvarchar](50) NULL,
	[SER_ED] [nvarchar](50) NULL,
	[LPAY] [decimal](16, 2) NULL,
	[NOTE] [nvarchar](max) NULL,
	[MAJOB] [nvarchar](max) NULL,
	[REA] [nvarchar](max) NULL,
	[RESUME_PNO] [nvarchar](50) NULL,
 CONSTRAINT [PK_RESUME_D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

