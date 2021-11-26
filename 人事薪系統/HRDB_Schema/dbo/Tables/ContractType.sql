CREATE TABLE [dbo].[ContractType] (
    [Code]             NVARCHAR (50) NOT NULL,
    [DisplayName]      NVARCHAR (50) NOT NULL,
    [MonthSpan]        INT           NOT NULL,
    [KeyDate]          DATETIME      NOT NULL,
    [KeyMan]           NVARCHAR (50) NOT NULL,
    [AlertDefaultDays] INT           NOT NULL,
    CONSTRAINT [PK_ContractType_1] PRIMARY KEY CLUSTERED ([Code] ASC)
);

