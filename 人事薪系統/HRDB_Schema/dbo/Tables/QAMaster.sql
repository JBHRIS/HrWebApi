CREATE TABLE [dbo].[QAMaster] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [QA_PublishedID]    INT            NOT NULL,
    [Nobr]              NVARCHAR (50)  NULL,
    [sysRole]           INT            NULL,
    [FillerCategory]    NVARCHAR (50)  NOT NULL,
    [DeptCode]          NVARCHAR (50)  NULL,
    [WriteDate]         DATETIME       NULL,
    [FillFormDatetimeB] DATETIME       NULL,
    [FillFormDatetimeE] DATETIME       NULL,
    [TotalScore]        INT            NULL,
    [FillInBy]          NVARCHAR (50)  NULL,
    [MailLog]           NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_QAMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

