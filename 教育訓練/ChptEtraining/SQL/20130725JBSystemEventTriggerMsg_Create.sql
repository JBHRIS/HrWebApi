USE [Formosa_eTraining]
GO

/****** Object:  Table [dbo].[JBSystemEventTriggerMsg]    Script Date: 2013/7/23 下午 03:55:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JBSystemEventTriggerMsg](
	[Guid] [nvarchar](50) NOT NULL,
	[SystemEventGuid] [nvarchar](50) NOT NULL,
	[NotifyMsgTplGuid] [nvarchar](50) NOT NULL,
	[Enable] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedMan] [nvarchar](50) NULL,
 CONSTRAINT [PK_SystemEventTriggerMsg] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[JBSystemEventTriggerMsg] ADD  CONSTRAINT [DF_SystemEventTriggerMsg_Enable]  DEFAULT ((0)) FOR [Enable]
GO

ALTER TABLE [dbo].[JBSystemEventTriggerMsg]  WITH CHECK ADD  CONSTRAINT [FK_JBSystemEventTriggerMsg_JBSystemEventTriggerMsg] FOREIGN KEY([Guid])
REFERENCES [dbo].[JBSystemEventTriggerMsg] ([Guid])
GO

ALTER TABLE [dbo].[JBSystemEventTriggerMsg] CHECK CONSTRAINT [FK_JBSystemEventTriggerMsg_JBSystemEventTriggerMsg]
GO

ALTER TABLE [dbo].[JBSystemEventTriggerMsg]  WITH CHECK ADD  CONSTRAINT [FK_SystemEventTriggerMsg_SystemEvent] FOREIGN KEY([SystemEventGuid])
REFERENCES [dbo].[JBSystemEvent] ([Guid])
GO

ALTER TABLE [dbo].[JBSystemEventTriggerMsg] CHECK CONSTRAINT [FK_SystemEventTriggerMsg_SystemEvent]
GO

