
CREATE TABLE [dbo].[EmployeeRule](
	[Auto] [int] IDENTITY(1,1) NOT NULL,
	[NOBR] [nvarchar](50) NOT NULL,
	[RuleType] [nvarchar](50) NOT NULL,
	[BeginDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Value] [nvarchar](500) NOT NULL,
	[Remark] [nvarchar](500) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EmployeeRule] PRIMARY KEY CLUSTERED 
(
	[Auto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


