USE [CHPTHR]
GO

/****** Object:  Table [dbo].[sysRole]    Script Date: 2013/8/5 下午 04:52:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[sysRole](
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsAdminRole] [bit] NOT NULL,
	[IsVisible] [bit] NOT NULL,
 CONSTRAINT [PK_sysRole] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[sysRole] ADD  CONSTRAINT [DF_sysRole_IsAdminRole]  DEFAULT ((0)) FOR [IsAdminRole]
GO

ALTER TABLE [dbo].[sysRole] ADD  CONSTRAINT [DF_sysRole_IsVisible]  DEFAULT ((1)) FOR [IsVisible]
GO

