CREATE TABLE [dbo].[qQuestionaryM] (
    [iAutoKey] INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [sCode]    NVARCHAR (50) NOT NULL,
    [sName]    NVARCHAR (50) NOT NULL,
    [sContent] NTEXT         NOT NULL,
    [sHeader]  NTEXT         NULL,
    [sFooter]  NTEXT         NULL,
    [sKeyMan]  NVARCHAR (50) NULL,
    [dKeyDate] DATETIME      NULL
);

