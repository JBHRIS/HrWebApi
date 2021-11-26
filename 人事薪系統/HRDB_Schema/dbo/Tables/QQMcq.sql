CREATE TABLE [dbo].[QQMcq] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [IsValueInt] BIT           CONSTRAINT [DF_QQMcq_IsValueInt] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_QQMcq] PRIMARY KEY CLUSTERED ([Id] ASC)
);

