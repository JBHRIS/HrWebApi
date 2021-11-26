CREATE TABLE [dbo].[MeetingRoom] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50) NOT NULL,
    [EnableSchedueRent] BIT           CONSTRAINT [DF_MeetingRoom_EnableSchedueRent] DEFAULT ((0)) NOT NULL,
    [CanRent]           BIT           CONSTRAINT [DF_MeetingRoom_CanRent] DEFAULT ((1)) NOT NULL,
    [DispBackColor]     INT           NULL,
    CONSTRAINT [PK_MeetingRoom] PRIMARY KEY CLUSTERED ([Id] ASC)
);

