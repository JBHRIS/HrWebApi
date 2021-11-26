/****** Object:  Table [dbo].[DiversionAttendType]    Script Date: 2021/6/4 ¤W¤È 09:28:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DiversionAttendType](
	[DiversionAttendType] [nvarchar](50) NOT NULL,
	[DiversionAttendTypeName] [nvarchar](50) NOT NULL,
	[CheckWFH_Attend] [bit] NOT NULL,
	[CheckWorkLog] [bit] NOT NULL,
	[CheckWebCard] [bit] NOT NULL,
	[CheckTemperoturyReport] [bit] NOT NULL,
	[KeyDate] [datetime] NOT NULL,
	[KeyMan] [nvarchar](50) NOT NULL,
	[AutoKey] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DiversionAttendType] PRIMARY KEY CLUSTERED 
(
	[AutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


