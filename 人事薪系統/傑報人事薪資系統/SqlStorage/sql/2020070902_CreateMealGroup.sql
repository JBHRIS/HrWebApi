/****** Object:  Table [dbo].[MealGroup]    Script Date: 2020/7/9 ¤U¤È 02:41:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MealGroup](
	[MealGroup_Code] [nvarchar](50) NOT NULL,
	[MealGroup_DISP] [nvarchar](50) NOT NULL,
	[MealGroup_Name] [nvarchar](50) NOT NULL,
	[NOTE] [nvarchar](500) NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_MealGroup] PRIMARY KEY CLUSTERED 
(
	[MealGroup_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


