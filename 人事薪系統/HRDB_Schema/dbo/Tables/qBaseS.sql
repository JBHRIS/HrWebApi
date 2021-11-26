CREATE TABLE [dbo].[qBaseS] (
    [iAutoKey]         INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [sBaseCode]        NVARCHAR (50) NOT NULL,
    [sQuestionaryCode] NVARCHAR (50) NOT NULL,
    [sCastCode]        NVARCHAR (50) NOT NULL,
    [sCate]            NVARCHAR (50) NOT NULL,
    [sThemeCode]       NVARCHAR (50) NULL,
    [iFraction]        INT           NULL,
    [sFraction]        NTEXT         NULL
);

