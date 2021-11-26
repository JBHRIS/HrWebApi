/****** Object:  Table [dbo].[DiversionGroup]    Script Date: 2021/6/4 ¤W¤È 09:25:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DiversionGroup](
	[EmployeeId] [nvarchar](50) NOT NULL,
	[BeginDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[DiversionGroupType] [nvarchar](50) NOT NULL,
	[WorkLocation] [nvarchar](50) NOT NULL,
	[KeyDate] [datetime] NOT NULL,
	[KeyMan] [nvarchar](50) NOT NULL,
	[AutoKey] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DiversionGroup] PRIMARY KEY CLUSTERED 
(
	[AutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


