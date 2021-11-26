CREATE TABLE [dbo].[qTheme] (
    [iAutoKey]   INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [sCode]      NVARCHAR (50) NOT NULL,
    [sName]      NVARCHAR (50) NOT NULL,
    [sContent]   NTEXT         NOT NULL,
    [sTitleCode] NVARCHAR (50) NOT NULL,
    [iOrder]     INT           NOT NULL,
    [sKeyMan]    NVARCHAR (50) CONSTRAINT [DF_qTheme_sKeyMan] DEFAULT ('') NOT NULL,
    [dKeyDate]   DATETIME      CONSTRAINT [DF_qTheme_dKeyDate] DEFAULT (getdate()) NOT NULL
);

