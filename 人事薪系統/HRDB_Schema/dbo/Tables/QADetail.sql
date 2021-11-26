CREATE TABLE [dbo].[QADetail] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [QAMasterId]     INT             NOT NULL,
    [QQItemId]       INT             NOT NULL,
    [McqIntValue]    INT             NULL,
    [McqStringValue] NVARCHAR (50)   NULL,
    [TfqValue]       BIT             NULL,
    [SaqValue]       NVARCHAR (2000) NULL,
    CONSTRAINT [PK_QADetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);

