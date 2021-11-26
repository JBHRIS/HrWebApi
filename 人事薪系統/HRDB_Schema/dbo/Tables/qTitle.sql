CREATE TABLE [dbo].[qTitle] (
    [iAutoKey]   INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [sCode]      NVARCHAR (50) NOT NULL,
    [sName]      NVARCHAR (50) NOT NULL,
    [sFraction1] NVARCHAR (50) CONSTRAINT [DF_qTitle_sFraction1] DEFAULT ('') NOT NULL,
    [sFraction2] NVARCHAR (50) CONSTRAINT [DF_qTitle_sFraction2] DEFAULT ('') NOT NULL,
    [sFraction3] NVARCHAR (50) CONSTRAINT [DF_qTitle_sFraction3] DEFAULT ('') NOT NULL,
    [sFraction4] NVARCHAR (50) CONSTRAINT [DF_qTitle_sFraction4] DEFAULT ('') NOT NULL,
    [sFraction5] NVARCHAR (50) CONSTRAINT [DF_qTitle_sFraction5] DEFAULT ('') NOT NULL,
    [sKeyMan]    NVARCHAR (50) CONSTRAINT [DF_qTitle_sKeyMan] DEFAULT ('') NOT NULL,
    [dKeyDate]   DATETIME      CONSTRAINT [DF_qTitle_dKeyDate] DEFAULT (getdate()) NOT NULL
);

