USE [IODATAHR]
GO
/****** 物件:  Table [dbo].[sysLoginPW]    指令碼日期: 04/22/2010 09:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysLoginPW](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sysLoginUser_sUserID] [nvarchar](50) NOT NULL,
	[sUserPWold] [nvarchar](50) NOT NULL,
	[sUserPWnew] [nvarchar](50) NOT NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_sysLoginPW] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
