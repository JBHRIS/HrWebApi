CREATE TABLE [dbo].[TraceLog] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Source]     NVARCHAR (50) NULL,
    [Inserted]   XML           NULL,
    [Deleted]    XML           NULL,
    [CreateTime] DATETIME      NULL,
    CONSTRAINT [PK_TraceLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

