CREATE TABLE [dbo].[DisabilityType] (
    [DisabilityCode] NVARCHAR (50) NOT NULL,
    [DisabilityName] NVARCHAR (50) NOT NULL,
    [KeyDate]        DATETIME      NOT NULL,
    [KeyMan]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_DisabilityType] PRIMARY KEY CLUSTERED ([DisabilityCode] ASC)
);

