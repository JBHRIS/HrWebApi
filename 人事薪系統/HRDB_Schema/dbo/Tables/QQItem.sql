CREATE TABLE [dbo].[QQItem] (
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [QuestionText]         NVARCHAR (1000) NOT NULL,
    [TypeCode]             NVARCHAR (50)   NOT NULL,
    [McqId]                INT             NULL,
    [McqDisplayHorizontal] BIT             CONSTRAINT [DF_QQItem_McqDisplayHorizontal] DEFAULT ((1)) NOT NULL,
    [IsRequired]           BIT             CONSTRAINT [DF_QQItem_IsRequired] DEFAULT ((1)) NOT NULL,
    [MinCharCount]         INT             NULL,
    [CreatedBy]            NVARCHAR (50)   NULL,
    [CreatedDate]          DATETIME        NULL,
    CONSTRAINT [PK_QQItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);

