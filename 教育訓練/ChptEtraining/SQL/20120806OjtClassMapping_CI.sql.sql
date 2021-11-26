USE [Formosa_eLearning]
GO

/****** Object:  Table [dbo].[Table_1]    Script Date: 08/21/2012 11:32:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OjtClassMapping](
	[OjtClass_Old] [nvarchar](255) NOT NULL,
	[OjtClass_new] [nvarchar](255) NULL,
 CONSTRAINT [PK_OjtClassMapping] PRIMARY KEY CLUSTERED 
(
	[OjtClass_Old] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

