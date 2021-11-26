
/****** Object:  Table [dbo].[NotifyDetail]    Script Date: 2021/5/10 下午 02:22:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pid] [int] NOT NULL,
	[Comp] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](500) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Recipient] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](500) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateMan] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NotifyDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NotifyMaster]    Script Date: 2021/5/10 下午 02:22:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotifyCode] [char](50) NOT NULL,
	[NotifyName] [nvarchar](50) NOT NULL,
	[QueryScript] [nvarchar](max) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateMan] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NotifyMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NotifyParameterDetail]    Script Date: 2021/5/10 下午 02:22:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyParameterDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotifyDetailId] [int] NOT NULL,
	[ParameterCode] [nvarchar](50) NOT NULL,
	[ParameterName] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[DataType] [nvarchar](50) NOT NULL,
	[FieldType] [nvarchar](50) NOT NULL,
	[Source] [nvarchar](max) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateMan] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NotifyParameterDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NotifyParameterMaster]    Script Date: 2021/5/10 下午 02:22:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyParameterMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotifyMasterId] [int] NOT NULL,
	[ParameterCode] [nvarchar](50) NOT NULL,
	[ParameterName] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[DataType] [nchar](50) NOT NULL,
	[FieldType] [nchar](50) NOT NULL,
	[Source] [nvarchar](max) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateMan] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NotifyParameterMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NotifyScheduleDetail]    Script Date: 2021/5/10 下午 02:22:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyScheduleDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pid] [int] NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[CreateMan] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_NotifyScheduleDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NotifyScheduleMaster]    Script Date: 2021/5/10 下午 02:22:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotifyScheduleMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotifyDetailId] [int] NOT NULL,
	[SetTime] [bigint] NOT NULL,
	[CreateMan] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_NotifyScheduleMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[NotifyDetail] ADD  CONSTRAINT [DF_NotifyDetail_Recipient]  DEFAULT ('') FOR [Recipient]
GO

CREATE View [dbo].[View_NotifySchedule]
as
select substring(CONVERT(varchar, DATEADD(MILLISECOND, a.SetTime/CAST(10000 AS BIGINT), '1900-01-01'),8),1,5) 啟動時間
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=0),'') 星期日
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=1),'') 星期一
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=2),'') 星期二
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=3),'') 星期三
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=4),'') 星期四
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=5),'') 星期五
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=6),'') 星期六
,a.Id,a.NotifyDetailId
from NotifyScheduleMaster a
go

