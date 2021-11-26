CREATE TABLE [dbo].[DisabilityRank] (
    [DisabilityRankCode] NVARCHAR (50) NOT NULL,
    [DisabilityRankName] NVARCHAR (50) NOT NULL,
    [KeyDate]            DATETIME      NOT NULL,
    [KeyMan]             NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_DisabilityRank] PRIMARY KEY CLUSTERED ([DisabilityRankCode] ASC)
);

