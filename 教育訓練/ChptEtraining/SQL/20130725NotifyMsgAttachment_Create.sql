USE [Formosa_eTraining]
GO

/****** Object:  Table [dbo].[NotifyMsgAttachment]    Script Date: 2013/7/23 下午 03:56:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyMsgAttachment](
	[NotifyMsgGuid] [nvarchar](50) NOT NULL,
	[Guid] [nvarchar](50) NOT NULL,
	[FileName] [nvarchar](255) NOT NULL,
	[FileStream] [image] NOT NULL,
 CONSTRAINT [PK_NotifyMsgAttachment] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[NotifyMsgAttachment]  WITH NOCHECK ADD  CONSTRAINT [FK_NotifyMsgAttachment_NotifyMsg] FOREIGN KEY([NotifyMsgGuid])
REFERENCES [dbo].[NotifyMsg] ([Guid])
GO

ALTER TABLE [dbo].[NotifyMsgAttachment] NOCHECK CONSTRAINT [FK_NotifyMsgAttachment_NotifyMsg]
GO

