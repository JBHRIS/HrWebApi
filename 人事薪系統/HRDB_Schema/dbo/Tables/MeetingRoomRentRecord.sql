CREATE TABLE [dbo].[MeetingRoomRentRecord] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [MeetingRoomId]     INT             NOT NULL,
    [StartDateTime]     DATETIME        NOT NULL,
    [EndDateTime]       DATETIME        NOT NULL,
    [UsedTimeHours]     INT             CONSTRAINT [DF_MeetingRoomRentRecord_UsedTimeHours] DEFAULT ((0)) NOT NULL,
    [UsedTimeMins]      INT             CONSTRAINT [DF_MeetingRoomRentRecord_UsedTimeMins] DEFAULT ((0)) NOT NULL,
    [UsedTotalMins]     INT             CONSTRAINT [DF_MeetingRoomRentRecord_UsedTotalMins] DEFAULT ((0)) NOT NULL,
    [Topic]             NVARCHAR (1000) NULL,
    [Contents]          NVARCHAR (MAX)  NULL,
    [EmailNotification] BIT             CONSTRAINT [DF_MeetingRoomRentRecord_EmailNotification] DEFAULT ((0)) NOT NULL,
    [WritedBy]          NVARCHAR (50)   NULL,
    [WritedDate]        DATETIME        NULL,
    [Cancel]            BIT             CONSTRAINT [DF_MeetingRoomRentRecord_Canceled] DEFAULT ((0)) NOT NULL,
    [Canceler]          NVARCHAR (50)   NULL,
    [GroupCode]         NVARCHAR (50)   NULL,
    CONSTRAINT [PK_MeetingRoomRentRecord] PRIMARY KEY CLUSTERED ([Id] ASC)
);

