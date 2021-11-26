CREATE TABLE [dbo].[NotifyTemplate] (
    [AutoKey]    INT            IDENTITY (1, 1) NOT NULL,
    [Comp]       NVARCHAR (50)  NOT NULL,
    [NotifyType] NVARCHAR (50)  NOT NULL,
    [TargetType] NVARCHAR (50)  NOT NULL,
    [Target]     NVARCHAR (50)  NOT NULL,
    [NotifyDay]  INT            NOT NULL,
    [Memo]       NVARCHAR (100) NOT NULL,
    [KeyDate]    DATETIME       NOT NULL,
    [KeyMan]     NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_NotifyTemplate] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

