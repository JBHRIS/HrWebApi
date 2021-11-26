CREATE TABLE [dbo].[QTplCategory] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [QTplCode]      NVARCHAR (50) NOT NULL,
    [QCategoryCode] NVARCHAR (50) NOT NULL,
    [Sequence]      INT           CONSTRAINT [DF_QTplCategory_Sequence] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_QTplCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

