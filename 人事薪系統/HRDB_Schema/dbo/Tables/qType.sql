CREATE TABLE [dbo].[qType] (
    [iAutoKey]         INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [sCode]            NVARCHAR (50) NOT NULL,
    [sName]            NVARCHAR (50) NOT NULL,
    [sQuestionaryCode] NVARCHAR (50) NOT NULL,
    [sQuestionaryName] NVARCHAR (50) NOT NULL,
    [dDateB]           DATETIME      NOT NULL,
    [dDateE]           DATETIME      NOT NULL,
    [iTotalFraction]   INT           NOT NULL,
    [sKeyMan]          NVARCHAR (50) CONSTRAINT [DF_qType_sKeyMan] DEFAULT ('') NOT NULL,
    [dKeyDate]         DATETIME      CONSTRAINT [DF_qType_dKeyDate] DEFAULT (getdate()) NOT NULL
);

