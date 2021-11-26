CREATE TABLE [dbo].[NotifyScheduleMaster] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [NotifyDetailId] INT           NOT NULL,
    [SetTime]        BIGINT        NOT NULL,
    [CreateMan]      NVARCHAR (50) NOT NULL,
    [CreateTime]     DATETIME      NOT NULL,
    CONSTRAINT [PK_NotifyScheduleMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

