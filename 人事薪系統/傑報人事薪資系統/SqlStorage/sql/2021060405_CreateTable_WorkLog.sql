/****** Object:  Table [dbo].[WorkLog]    Script Date: 2021/6/4 ¤W¤È 09:26:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WorkLog](
	[EmployeeId] [nvarchar](50) NOT NULL,
	[AttendDate] [datetime] NOT NULL,
	[BeginTime] [nvarchar](50) NOT NULL,
	[EndTime] [nvarchar](50) NOT NULL,
	[WorkHours] [decimal](16, 2) NOT NULL,
	[Workitem] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[FileId] [nvarchar](50) NULL,
	[KeyDate] [datetime] NOT NULL,
	[KeyMan] [nvarchar](50) NOT NULL,
	[AutoKey] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_WorkLog] PRIMARY KEY CLUSTERED 
(
	[AutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


