
/****** Object:  Table [dbo].[JBSystem]    Script Date: 2013/7/23 下午 03:55:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JBSystem](
	[Guid] [nvarchar](50) NOT NULL,
	[SystemCode] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_JbSystem] PRIMARY KEY CLUSTERED 
(
	[SystemCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

