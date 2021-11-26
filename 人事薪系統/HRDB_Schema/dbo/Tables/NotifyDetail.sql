CREATE TABLE [dbo].[NotifyDetail] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Pid]             INT            NOT NULL,
    [Comp]            NVARCHAR (50)  NOT NULL,
    [Subject]         NVARCHAR (500) NOT NULL,
    [Body]            NVARCHAR (MAX) NOT NULL,
    [Recipient]       NVARCHAR (MAX) CONSTRAINT [DF_NotifyDetail_Recipient] DEFAULT ('') NOT NULL,
    [Status]          NVARCHAR (50)  NOT NULL,
    [Remark]          NVARCHAR (500) NOT NULL,
    [CreateTime]      DATETIME       NOT NULL,
    [CreateMan]       NVARCHAR (50)  NOT NULL,
    [ContentArgQuery] NVARCHAR (MAX) CONSTRAINT [DF_NotifyDetail_ContentArgQuery] DEFAULT ('') NULL,
    CONSTRAINT [PK_NotifyDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);

