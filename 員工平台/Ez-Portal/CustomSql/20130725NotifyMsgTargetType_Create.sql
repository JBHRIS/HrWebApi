
/****** Object:  Table [dbo].[NotifyMsgTargetType]    Script Date: 2013/7/23 下午 03:57:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyMsgTargetType](
	[Guid] [nvarchar](50) NOT NULL,
	[NotifyMsgTargetGuid] [nvarchar](50) NOT NULL,
	[NotifyTypeCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NotifyMsgTargetType] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[NotifyMsgTargetType]  WITH NOCHECK ADD  CONSTRAINT [FK_NotifyMsgTargetType_NotifyMsgTarget] FOREIGN KEY([NotifyMsgTargetGuid])
REFERENCES [dbo].[NotifyMsgTarget] ([Guid])
GO

ALTER TABLE [dbo].[NotifyMsgTargetType] NOCHECK CONSTRAINT [FK_NotifyMsgTargetType_NotifyMsgTarget]
GO

ALTER TABLE [dbo].[NotifyMsgTargetType]  WITH NOCHECK ADD  CONSTRAINT [FK_NotifyMsgTargetType_NotifyType] FOREIGN KEY([NotifyTypeCode])
REFERENCES [dbo].[NotifyType] ([NotifyTypeCode])
GO

ALTER TABLE [dbo].[NotifyMsgTargetType] NOCHECK CONSTRAINT [FK_NotifyMsgTargetType_NotifyType]
GO

