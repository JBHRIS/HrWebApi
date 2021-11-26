USE [CHPTHR]
GO

/****** Object:  Table [dbo].[CarRentRecord]    Script Date: 11/20/2013 22:58:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarRentRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[UsedTimeHours] [int] NOT NULL,
	[UsedTimeMins] [int] NOT NULL,
	[UsedTotalMins] [int] NOT NULL,
	[Destination] [nvarchar](1000) NULL,
	[Contents] [nvarchar](2000) NULL,
	[WritedBy] [nvarchar](50) NULL,
	[WritedDate] [datetime] NULL,
	[Cancel] [bit] NOT NULL,
	[Canceler] [nvarchar](50) NULL,
	[MileageBeforeRent] [int] NULL,
	[MileageAfterRent] [int] NULL,
 CONSTRAINT [PK_CarRentRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CarRentRecord] ADD  CONSTRAINT [DF_CarRentRecord_UsedTimeHours]  DEFAULT ((0)) FOR [UsedTimeHours]
GO

ALTER TABLE [dbo].[CarRentRecord] ADD  CONSTRAINT [DF_CarRentRecord_UsedTimeMins]  DEFAULT ((0)) FOR [UsedTimeMins]
GO

ALTER TABLE [dbo].[CarRentRecord] ADD  CONSTRAINT [DF_CarRentRecord_UsedTotalMins]  DEFAULT ((0)) FOR [UsedTotalMins]
GO

ALTER TABLE [dbo].[CarRentRecord] ADD  CONSTRAINT [DF_CarRentRecord_Cancel]  DEFAULT ((0)) FOR [Cancel]
GO

