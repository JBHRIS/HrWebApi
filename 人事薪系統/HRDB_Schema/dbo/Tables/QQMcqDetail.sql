CREATE TABLE [dbo].[QQMcqDetail] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [QQMcqId]     INT           NOT NULL,
    [Sequence]    INT           CONSTRAINT [DF_QQMcqDetail_Sequence] DEFAULT ((0)) NOT NULL,
    [Text]        NVARCHAR (50) NOT NULL,
    [StringValue] NVARCHAR (50) NULL,
    [IntValue]    INT           NULL,
    CONSTRAINT [PK_QQMcqDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);

