CREATE TABLE [dbo].[QQMcqDetailTpl] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [GroupCode]   NVARCHAR (50) NOT NULL,
    [Sequence]    INT           CONSTRAINT [DF_QQMcqDetailTpl_Sequence] DEFAULT ((0)) NOT NULL,
    [Text]        NVARCHAR (50) NOT NULL,
    [StringValue] NVARCHAR (50) NULL,
    [IntValue]    INT           NULL,
    CONSTRAINT [PK_QQMcqDetailTpl] PRIMARY KEY CLUSTERED ([Id] ASC)
);

