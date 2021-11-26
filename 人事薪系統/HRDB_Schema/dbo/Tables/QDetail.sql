CREATE TABLE [dbo].[QDetail] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [QTplCategoryId] INT NOT NULL,
    [QQItemId]       INT NOT NULL,
    [Sequence]       INT NOT NULL,
    [IsRequired]     BIT CONSTRAINT [DF_QDetail_IsRequired] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_QDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);

