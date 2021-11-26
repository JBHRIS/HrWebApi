

/****** Object:  Table [dbo].[NotifyMsg]    Script Date: 2013/7/23 下午 03:56:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyMsg](
	[Guid] [nvarchar](50) NOT NULL,
	[SystemEventGuid] [nvarchar](50) NULL,
	[NotifyMsgTplGuid] [nvarchar](50) NULL,
	[SourceSystem] [nvarchar](50) NOT NULL,
	[SourceProgram] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[NotifyAdate] [datetime] NOT NULL,
	[NotifyDdate] [datetime] NULL,
	[IsProcessed] [bit] NOT NULL,
	[NeedCheckBbs] [bit] NOT NULL,
	[IsTemplate] [bit] NOT NULL,
 CONSTRAINT [PK_NotifyMsg] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[NotifyMsg] ADD  CONSTRAINT [DF_NotifyMsg_IsProcessed]  DEFAULT ((0)) FOR [IsProcessed]
GO

ALTER TABLE [dbo].[NotifyMsg] ADD  CONSTRAINT [DF_NotifyMsg_NeedCheckBbs]  DEFAULT ((0)) FOR [NeedCheckBbs]
GO

ALTER TABLE [dbo].[NotifyMsg] ADD  CONSTRAINT [DF_NotifyMsg_IsTemplate]  DEFAULT ((0)) FOR [IsTemplate]
GO

ALTER TABLE [dbo].[NotifyMsg]  WITH NOCHECK ADD  CONSTRAINT [FK_NotifyMsg_JBSystemEventTriggerMsg] FOREIGN KEY([SystemEventGuid])
REFERENCES [dbo].[JBSystemEventTriggerMsg] ([Guid])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[NotifyMsg] NOCHECK CONSTRAINT [FK_NotifyMsg_JBSystemEventTriggerMsg]
GO

