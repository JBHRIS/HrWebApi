CREATE TABLE [dbo].[qCastM] (
    [iAutoKey] INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [sCode]    NVARCHAR (50) NOT NULL,
    [sName]    NVARCHAR (50) NOT NULL,
    [sContent] NTEXT         NOT NULL,
    [iOrder]   INT           NOT NULL,
    [sCate]    NVARCHAR (50) NOT NULL,
    [sKeyMan]  NVARCHAR (50) CONSTRAINT [DF_qCastM_sKeyMan] DEFAULT ('') NOT NULL,
    [dKeyDate] DATETIME      CONSTRAINT [DF_qCastM_dKeyDate] DEFAULT (getdate()) NOT NULL
);

