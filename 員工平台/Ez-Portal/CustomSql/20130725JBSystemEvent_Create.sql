
/****** Object:  Table [dbo].[JBSystemEvent]    Script Date: 2013/7/23 下午 03:55:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JBSystemEvent](
	[Guid] [nvarchar](50) NOT NULL,
	[SystemCode] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_SystemEvent] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[JBSystemEvent]  WITH NOCHECK ADD  CONSTRAINT [FK_SystemEvent_System] FOREIGN KEY([SystemCode])
REFERENCES [dbo].[JBSystem] ([SystemCode])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[JBSystemEvent] NOCHECK CONSTRAINT [FK_SystemEvent_System]
GO

