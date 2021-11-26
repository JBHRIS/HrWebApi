DROP TABLE [dbo].[EFFEMPLOY]
go 

/****** Object:  Table [dbo].[EFFEMPLOY]    Script Date: 2019/11/12 下午 02:18:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EFFEMPLOY](
	[YYMM] [nvarchar](50) NOT NULL,
	[NOBR] [nvarchar](50) NOT NULL,
	[EFFSCORE] [decimal](16, 2) NOT NULL,
	[EFFLVL] [nvarchar](50) NOT NULL,
	[IMPORT] [bit] NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
	[EFFTYPE] [nvarchar](50) NULL,
	[AUTOKEY] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AUTOKEY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EFFTYPE]    Script Date: 2019/11/12 下午 01:51:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EFFTYPE](
	[EFFTYPE] [nvarchar](50) NOT NULL,
	[EFFTYPE_DISP] [nvarchar](50) NOT NULL,
	[EFFTYPE_NAME] [nvarchar](50) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[AssessCat]    Script Date: 2019/11/12 下午 01:48:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AssessCat](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sTemplateCode] [nvarchar](50) NOT NULL,
	[sCode] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](200) NOT NULL,
	[iOrder] [int] NOT NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_AssessCat] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uc_AssessCatID] UNIQUE NONCLUSTERED 
(
	[sTemplateCode] ASC,
	[sCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Assess]    Script Date: 2019/11/12 下午 01:48:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Assess](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[AssessCat_sCode] [nvarchar](50) NOT NULL,
	[sCode] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](500) NOT NULL,
	[sFraction] [nvarchar](50) NOT NULL,
	[sOrder] [int] NOT NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_Assess] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uc_AssessID] UNIQUE NONCLUSTERED 
(
	[AssessCat_sCode] ASC,
	[sCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[EFFLVL]    Script Date: 2019/11/12 下午 01:48:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EFFLVL](
	[EFFLVL] [nvarchar](50) NOT NULL,
	[EFFLVL_DISP] [nvarchar](50) NOT NULL,
	[EFFLVL_NAME] [nvarchar](50) NOT NULL,
	[EFFB] [decimal](16, 2) NOT NULL,
	[EFFE] [decimal](16, 2) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO


