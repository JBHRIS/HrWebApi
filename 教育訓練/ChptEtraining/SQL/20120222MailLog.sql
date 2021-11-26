USE [Formosa_eLearning]
GO

/****** Object:  Table [dbo].[MailLog]    Script Date: 02/22/2012 15:23:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MailLog](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[MailTemplate] [int] NULL,
	[MailSubject] [nvarchar](2000) NULL,
	[MailContent] [nvarchar](2000) NULL,
	[MailAddressee] [nvarchar](2000) NULL,
	[ErrorMsg] [nvarchar](2000) NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_MailLog] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

