USE [NYLOKHR_eTraining]
GO

/****** Object:  Table [dbo].[NotifyCustomVariable]    Script Date: 2013/4/15 下午 04:56:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyCustomVariable](
	[Code] [nvarchar](50) NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_NotifyVariables] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

