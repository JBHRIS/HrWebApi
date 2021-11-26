/****** Object:  Table [dbo].[MealCaseSetting]    Script Date: 2020/7/9 ¤U¤È 02:41:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MealCaseSetting](
	[MealSettingCode] [nvarchar](50) NOT NULL,
	[MealGroup] [nvarchar](50) NOT NULL,
	[MealType] [nvarchar](50) NOT NULL,
	[Apply] [bit] NOT NULL,
	[Attend] [bit] NOT NULL,
	[OT] [bit] NOT NULL,
	[Eat] [bit] NOT NULL,
	[AMT] [decimal](16, 2) NOT NULL,
	[NOTE] [nvarchar](500) NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_MealCaseSetting] PRIMARY KEY CLUSTERED 
(
	[MealSettingCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


