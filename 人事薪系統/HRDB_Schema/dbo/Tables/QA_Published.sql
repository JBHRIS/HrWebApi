CREATE TABLE [dbo].[QA_Published] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [QTplCode]           NVARCHAR (50)  NOT NULL,
    [PublishDatetime]    DATETIME       NOT NULL,
    [FillFormDatetimeB]  DATETIME       NOT NULL,
    [FillFormDatetimeE]  DATETIME       NOT NULL,
    [IsPublished]        BIT            CONSTRAINT [DF_QA_Published_IsPublished] DEFAULT ((0)) NOT NULL,
    [WritedBy]           NVARCHAR (50)  NULL,
    [SentMail]           BIT            CONSTRAINT [DF_QA_Published_SentMail] DEFAULT ((0)) NOT NULL,
    [MailSubject]        NVARCHAR (MAX) NULL,
    [MailContent]        NVARCHAR (MAX) NULL,
    [Cancel]             BIT            CONSTRAINT [DF_QA_Published_Cancel] DEFAULT ((0)) NOT NULL,
    [IsAnonymous]        BIT            CONSTRAINT [DF_QA_Published_IsAnonymou] DEFAULT ((0)) NOT NULL,
    [ViewSummaryOpening] BIT            CONSTRAINT [DF_QA_Published_ViewSummaryOpening_1] DEFAULT ((0)) NOT NULL,
    [ViewSummaryClosed]  BIT            CONSTRAINT [DF_QA_Published_ViewSummaryClosed_1] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_QA_Published] PRIMARY KEY CLUSTERED ([Id] ASC)
);

