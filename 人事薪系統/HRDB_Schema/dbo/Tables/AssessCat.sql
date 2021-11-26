CREATE TABLE [dbo].[AssessCat] (
    [iAutoKey]      INT            IDENTITY (1, 1) NOT NULL,
    [sTemplateCode] NVARCHAR (50)  NOT NULL,
    [sCode]         NVARCHAR (50)  NOT NULL,
    [sName]         NVARCHAR (200) NOT NULL,
    [iOrder]        INT            NOT NULL,
    [sKeyMan]       NVARCHAR (50)  NULL,
    [dKeyDate]      DATETIME       NULL,
    CONSTRAINT [PK_AssessCat] PRIMARY KEY CLUSTERED ([iAutoKey] ASC),
    CONSTRAINT [uc_AssessCatID] UNIQUE NONCLUSTERED ([sTemplateCode] ASC, [sCode] ASC)
);

