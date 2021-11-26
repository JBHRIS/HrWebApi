CREATE TABLE [dbo].[CarRentRecord] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [CarId]             INT             NOT NULL,
    [StartDateTime]     DATETIME        NOT NULL,
    [EndDateTime]       DATETIME        NOT NULL,
    [UsedTimeHours]     INT             CONSTRAINT [DF_CarRentRecord_UsedTimeHours] DEFAULT ((0)) NOT NULL,
    [UsedTimeMins]      INT             CONSTRAINT [DF_CarRentRecord_UsedTimeMins] DEFAULT ((0)) NOT NULL,
    [UsedTotalMins]     INT             CONSTRAINT [DF_CarRentRecord_UsedTotalMins] DEFAULT ((0)) NOT NULL,
    [Destination]       NVARCHAR (1000) NULL,
    [Contents]          NVARCHAR (2000) NULL,
    [WritedBy]          NVARCHAR (50)   NULL,
    [WritedDate]        DATETIME        NULL,
    [Cancel]            BIT             CONSTRAINT [DF_CarRentRecord_Cancel] DEFAULT ((0)) NOT NULL,
    [Canceler]          NVARCHAR (50)   NULL,
    [MileageBeforeRent] INT             NULL,
    [MileageAfterRent]  INT             NULL,
    CONSTRAINT [PK_CarRentRecord] PRIMARY KEY CLUSTERED ([Id] ASC)
);

