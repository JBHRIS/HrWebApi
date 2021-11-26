CREATE TABLE [dbo].[MeetingRoomRentAttendee] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [MeetingRoomRentRecordId] INT           NOT NULL,
    [EmpNo]                   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_MeetingRoomRentAttendee] PRIMARY KEY CLUSTERED ([Id] ASC)
);

