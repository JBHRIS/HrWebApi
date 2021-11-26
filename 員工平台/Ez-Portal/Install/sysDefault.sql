USE [IODATAHR]
GO
/****** 物件:  Table [dbo].[sysDefault]    指令碼日期: 04/22/2010 09:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysDefault](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sName] [nvarchar](200) NULL,
	[sCategory] [nvarchar](50) NOT NULL,
	[sKey] [nvarchar](50) NOT NULL,
	[sValue] [nvarchar](200) NULL,
	[sType] [nvarchar](50) NOT NULL,
	[iOrder] [int] NOT NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_sysDefault] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
