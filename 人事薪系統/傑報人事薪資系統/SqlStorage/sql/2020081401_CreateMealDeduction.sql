/****** Object:  Table [dbo].[MealDeduction]    Script Date: 2020/8/14 ¤U¤È 04:01:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MealDeduction](
	[AutoKey] [int] IDENTITY(1,1) NOT NULL,
	[NOBR] [nvarchar](50) NOT NULL,
	[ADATE] [datetime] NOT NULL,
	[YYMM] [nvarchar](50) NULL,
	[MealGroup] [nvarchar](50) NOT NULL,
	[MealType] [nvarchar](50) NOT NULL,
	[Apply] [bit] NOT NULL,
	[Attend] [bit] NOT NULL,
	[OT] [bit] NOT NULL,
	[Eat] [bit] NOT NULL,
	[AMT] [decimal](16, 4) NOT NULL,
	[NOTE] [nvarchar](500) NULL,
	[SERO] [nvarchar](50) NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_MealDeduction] PRIMARY KEY CLUSTERED 
(
	[AutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MealDeduction] ADD  CONSTRAINT [DF_Table_1_APPLY]  DEFAULT ((0)) FOR [Apply]
GO

ALTER TABLE [dbo].[MealDeduction] ADD  CONSTRAINT [DF_Table_1_ATTEND]  DEFAULT ((0)) FOR [Attend]
GO

ALTER TABLE [dbo].[MealDeduction] ADD  CONSTRAINT [DF_MealDeduction_OT]  DEFAULT ((0)) FOR [OT]
GO

ALTER TABLE [dbo].[MealDeduction] ADD  CONSTRAINT [DF_Table_1_FINISHED]  DEFAULT ((0)) FOR [Eat]
GO

ALTER TABLE [dbo].[MealDeduction] ADD  CONSTRAINT [DF_MealDeduction_AMT]  DEFAULT ((0)) FOR [AMT]
GO


