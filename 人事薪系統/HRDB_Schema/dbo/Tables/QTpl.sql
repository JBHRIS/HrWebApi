CREATE TABLE [dbo].[QTpl] (
    [Code]           NVARCHAR (50)  NOT NULL,
    [Name]           NVARCHAR (50)  NOT NULL,
    [FillerCategory] NVARCHAR (10)  NOT NULL,
    [FillFormSpan]   INT            NOT NULL,
    [KeyMan]         NVARCHAR (50)  NULL,
    [KeyDate]        DATETIME       NULL,
    [BeenUsed]       BIT            CONSTRAINT [DF_QTpl_IsBeenUsed] DEFAULT ((0)) NOT NULL,
    [HeaderText]     NVARCHAR (MAX) NULL,
    [FooterText]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_QTpl] PRIMARY KEY CLUSTERED ([Code] ASC)
);

