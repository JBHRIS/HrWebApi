CREATE TABLE [dbo].[NotifyScheduleDetail] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Pid]        INT           NOT NULL,
    [DayOfWeek]  INT           NOT NULL,
    [CreateMan]  NVARCHAR (50) NOT NULL,
    [CreateTime] DATETIME      NOT NULL,
    CONSTRAINT [PK_NotifyScheduleDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);

