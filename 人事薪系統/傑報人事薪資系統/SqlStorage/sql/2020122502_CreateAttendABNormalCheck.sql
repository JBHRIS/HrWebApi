/****** Object:  Table [dbo].[ATTEND_ABNORMAL_CHECK]    Script Date: 2020/9/8 �U�� 02:06:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ATTEND_ABNORMAL_CHECK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOBR] [nvarchar](50) NOT NULL,
	[ADATE] [datetime] NOT NULL,
	[TYPE] [nvarchar](50) NOT NULL,
	[REMARK_TYPE] [nvarchar](50) NOT NULL,
	[REMARK] [nvarchar](max) NULL,
	[SERNO] [nvarchar](50) NULL,
	[CREATE_DATE] [datetime] NOT NULL,
	[CREATE_MAN] [nvarchar](50) NOT NULL,
	[UPDATE_DATE] [datetime] NOT NULL,
	[UPDATE_MAN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ATTEND_ABNORMAL_CHECK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


