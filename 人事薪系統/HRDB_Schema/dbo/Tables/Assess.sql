CREATE TABLE [dbo].[Assess] (
    [iAutoKey]        INT            IDENTITY (1, 1) NOT NULL,
    [AssessCat_sCode] NVARCHAR (50)  NOT NULL,
    [sCode]           NVARCHAR (50)  NOT NULL,
    [sName]           NVARCHAR (500) NOT NULL,
    [sFraction]       NVARCHAR (50)  NOT NULL,
    [sOrder]          INT            NOT NULL,
    [sKeyMan]         NVARCHAR (50)  NULL,
    [dKeyDate]        NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Assess] PRIMARY KEY CLUSTERED ([iAutoKey] ASC),
    CONSTRAINT [uc_AssessID] UNIQUE NONCLUSTERED ([AssessCat_sCode] ASC, [sCode] ASC)
);

