CREATE TABLE [dbo].[Contract] (
    [AutoKey]           INT           IDENTITY (1, 1) NOT NULL,
    [Nobr]              NVARCHAR (50) NOT NULL,
    [ContractType]      NVARCHAR (50) NOT NULL,
    [Adate]             DATETIME      NOT NULL,
    [Ddate]             DATETIME      NOT NULL,
    [WorkAdr]           NVARCHAR (50) NOT NULL,
    [KeyDate]           DATETIME      NOT NULL,
    [KeyMan]            NVARCHAR (50) NOT NULL,
    [NotifyMessageGuid] NVARCHAR (50) NULL,
    [AlertDay]          INT           NULL,
    CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED ([AutoKey] ASC),
    CONSTRAINT [FK_Contract_BASE] FOREIGN KEY ([Nobr]) REFERENCES [dbo].[BASE] ([NOBR]),
    CONSTRAINT [FK_Contract_ContractType1] FOREIGN KEY ([ContractType]) REFERENCES [dbo].[ContractType] ([Code])
);

