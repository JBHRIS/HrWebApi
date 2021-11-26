CREATE TABLE [dbo].[NotifyMaster] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [NotifyCode]      CHAR (50)      NOT NULL,
    [NotifyName]      NVARCHAR (50)  NOT NULL,
    [QueryScript]     NVARCHAR (MAX) NOT NULL,
    [CreateTime]      DATETIME       NOT NULL,
    [CreateMan]       NVARCHAR (50)  NOT NULL,
    [ContentArgQuery] NVARCHAR (MAX) CONSTRAINT [DF_NotifyMaster_ContentArgQuery] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_NotifyMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

