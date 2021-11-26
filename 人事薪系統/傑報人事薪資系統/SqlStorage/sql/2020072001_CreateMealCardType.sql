/****** Object:  Table [dbo].[MealCardType]    Script Date: 2020/7/21 ¤W¤È 11:38:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MealCardType](
	[AutoKey] [int] IDENTITY(1,1) NOT NULL,
	[NOBR] [nvarchar](50) NOT NULL,
	[ADATE] [datetime] NOT NULL,
	[BTIME] [nvarchar](50) NULL,
	[BTIME_Source] [nvarchar](50) NOT NULL,
	[MealType] [nvarchar](50) NULL,
	[MealGroup] [nvarchar](50) NULL,
	[NoTrans] [bit] NOT NULL,
	[Lost] [bit] NOT NULL,
	[SeroNo] [nvarchar](50) NOT NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_MealCardType] PRIMARY KEY CLUSTERED 
(
	[AutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


