USE [CHPTHR]
GO

/****** Object:  Table [dbo].[MeetingRoomRentRecord]    Script Date: 2013/11/27 上午 11:52:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MeetingRoomRentRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MeetingRoomId] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[UsedTimeHours] [int] NOT NULL,
	[UsedTimeMins] [int] NOT NULL,
	[UsedTotalMins] [int] NOT NULL,
	[Topic] [nvarchar](1000) NULL,
	[Contents] [nvarchar](max) NULL,
	[EmailNotification] [bit] NOT NULL,
	[WritedBy] [nvarchar](50) NULL,
	[WritedDate] [datetime] NULL,
	[Cancel] [bit] NOT NULL,
	[Canceler] [nvarchar](50) NULL,
	[GroupCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_MeetingRoomRentRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[MeetingRoomRentRecord] ADD  CONSTRAINT [DF_MeetingRoomRentRecord_UsedTimeHours]  DEFAULT ((0)) FOR [UsedTimeHours]
GO

ALTER TABLE [dbo].[MeetingRoomRentRecord] ADD  CONSTRAINT [DF_MeetingRoomRentRecord_UsedTimeMins]  DEFAULT ((0)) FOR [UsedTimeMins]
GO

ALTER TABLE [dbo].[MeetingRoomRentRecord] ADD  CONSTRAINT [DF_MeetingRoomRentRecord_UsedTotalMins]  DEFAULT ((0)) FOR [UsedTotalMins]
GO

ALTER TABLE [dbo].[MeetingRoomRentRecord] ADD  CONSTRAINT [DF_MeetingRoomRentRecord_EmailNotification]  DEFAULT ((0)) FOR [EmailNotification]
GO

ALTER TABLE [dbo].[MeetingRoomRentRecord] ADD  CONSTRAINT [DF_MeetingRoomRentRecord_Canceled]  DEFAULT ((0)) FOR [Cancel]
GO

