USE [IODATAHR]
GO
/****** 物件:  Table [dbo].[sysLoginTime]    指令碼日期: 04/22/2010 09:05:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysLoginTime](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sysLoginUser_sUserID] [nvarchar](50) NOT NULL,
	[sLoginIP] [nvarchar](50) NOT NULL,
	[bLoginSuccess] [bit] NOT NULL,
	[sSessionid] [nvarchar](50) NOT NULL,
	[dLoginTime] [datetime] NULL,
	[dLogoutTime] [datetime] NULL,
 CONSTRAINT [PK_sysLoginTime] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
