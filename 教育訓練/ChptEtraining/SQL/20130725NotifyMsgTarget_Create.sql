USE [Formosa_eTraining]
GO

/****** Object:  Table [dbo].[NotifyMsgTarget]    Script Date: 2013/7/23 下午 03:57:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyMsgTarget](
	[Guid] [nvarchar](50) NOT NULL,
	[NotifyMsgGuid] [nvarchar](50) NOT NULL,
	[NotifyTargetTypeCode] [nvarchar](50) NOT NULL,
	[NotifyTarget] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NotifyMsgTarget] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[NotifyMsgTarget]  WITH NOCHECK ADD  CONSTRAINT [FK_NotifyMsgTarget_NotifyMsg] FOREIGN KEY([NotifyMsgGuid])
REFERENCES [dbo].[NotifyMsg] ([Guid])
GO

ALTER TABLE [dbo].[NotifyMsgTarget] NOCHECK CONSTRAINT [FK_NotifyMsgTarget_NotifyMsg]
GO

ALTER TABLE [dbo].[NotifyMsgTarget]  WITH NOCHECK ADD  CONSTRAINT [FK_NotifyMsgTarget_NotifyTargetType] FOREIGN KEY([NotifyTargetTypeCode])
REFERENCES [dbo].[NotifyTargetType] ([NotifyTargetTypeCode])
GO

ALTER TABLE [dbo].[NotifyMsgTarget] NOCHECK CONSTRAINT [FK_NotifyMsgTarget_NotifyTargetType]
GO

