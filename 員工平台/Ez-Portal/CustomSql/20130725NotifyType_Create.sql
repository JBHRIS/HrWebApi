
/****** Object:  Table [dbo].[NotifyType]    Script Date: 2013/7/23 下午 03:57:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyType](
	[NotifyTypeCode] [nvarchar](50) NOT NULL,
	[NotifyTypeDescription] [nvarchar](200) NULL,
 CONSTRAINT [PK_NotifiedType] PRIMARY KEY CLUSTERED 
(
	[NotifyTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

