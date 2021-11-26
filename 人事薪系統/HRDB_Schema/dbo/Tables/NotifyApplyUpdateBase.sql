CREATE TABLE [dbo].[NotifyApplyUpdateBase] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [DataGroup] NVARCHAR (50) NOT NULL,
    [Nobr]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_NotifyApplyUpdateBase] PRIMARY KEY CLUSTERED ([Id] ASC)
);

