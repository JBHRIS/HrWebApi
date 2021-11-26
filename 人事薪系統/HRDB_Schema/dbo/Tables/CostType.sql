CREATE TABLE [dbo].[CostType] (
    [CostTypeCode] NVARCHAR (50) NOT NULL,
    [CostTypeName] NVARCHAR (50) NOT NULL,
    [KeyDate]      DATETIME      NOT NULL,
    [KeyMan]       NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CostType] PRIMARY KEY CLUSTERED ([CostTypeCode] ASC)
);

