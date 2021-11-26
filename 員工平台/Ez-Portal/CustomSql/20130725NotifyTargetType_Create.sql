

/****** Object:  Table [dbo].[NotifyTargetType]    Script Date: 2013/7/23 下午 03:57:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyTargetType](
	[NotifyTargetTypeCode] [nvarchar](50) NOT NULL,
	[NotifyTargetTypeDescription] [nvarchar](200) NULL,
 CONSTRAINT [PK_NotifiedTargetType] PRIMARY KEY CLUSTERED 
(
	[NotifyTargetTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

