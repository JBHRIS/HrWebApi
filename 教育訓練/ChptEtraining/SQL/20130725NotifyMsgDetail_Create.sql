USE [Formosa_eTraining]
GO

/****** Object:  Table [dbo].[NotifyMsgDetail]    Script Date: 2013/7/23 下午 03:56:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyMsgDetail](
	[Guid] [nvarchar](50) NOT NULL,
	[NotifyMsgGuid] [nvarchar](50) NOT NULL,
	[NotifyTarget] [nvarchar](50) NOT NULL,
	[NotifyTargetType] [nvarchar](50) NOT NULL,
	[NotifyTypeCode] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Message] [nvarchar](max) NULL,
	[Email] [nvarchar](255) NULL,
	[MailTo] [nvarchar](2000) NULL,
	[IsMailSent] [bit] NOT NULL,
	[ErrorMsg] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[NotifyAdate] [datetime] NOT NULL,
	[NotifyDdate] [datetime] NULL,
	[IsBbsChecked] [bit] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_NotifyMsgDetail] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[NotifyMsgDetail] ADD  CONSTRAINT [DF_NotifyMsgDetail_IsMailSent]  DEFAULT ((0)) FOR [IsMailSent]
GO

ALTER TABLE [dbo].[NotifyMsgDetail] ADD  CONSTRAINT [DF_NotifyMsgDetail_IsBbsChecked]  DEFAULT ((0)) FOR [IsBbsChecked]
GO

ALTER TABLE [dbo].[NotifyMsgDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_NotifyMsgDetail_NotifyMsg] FOREIGN KEY([NotifyMsgGuid])
REFERENCES [dbo].[NotifyMsg] ([Guid])
GO

ALTER TABLE [dbo].[NotifyMsgDetail] NOCHECK CONSTRAINT [FK_NotifyMsgDetail_NotifyMsg]
GO

ALTER TABLE [dbo].[NotifyMsgDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_NotifyMsgDetail_NotifyTargetType] FOREIGN KEY([NotifyTargetType])
REFERENCES [dbo].[NotifyTargetType] ([NotifyTargetTypeCode])
GO

ALTER TABLE [dbo].[NotifyMsgDetail] NOCHECK CONSTRAINT [FK_NotifyMsgDetail_NotifyTargetType]
GO

ALTER TABLE [dbo].[NotifyMsgDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_NotifyMsgDetail_NotifyType] FOREIGN KEY([NotifyTypeCode])
REFERENCES [dbo].[NotifyType] ([NotifyTypeCode])
GO

ALTER TABLE [dbo].[NotifyMsgDetail] NOCHECK CONSTRAINT [FK_NotifyMsgDetail_NotifyType]
GO

