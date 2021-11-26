CREATE TABLE [dbo].[BonusGroup] (
    [Code]      NVARCHAR (50) NOT NULL,
    [GroupName] NVARCHAR (50) NOT NULL,
    [Sort]      INT           NOT NULL,
    [KeyDate]   DATETIME      NOT NULL,
    [KeyMan]    NVARCHAR (50) NOT NULL,
    [Temp1]     NVARCHAR (50) NULL,
    [Temp2]     NVARCHAR (50) NULL,
    [Temp3]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_BonusGroup] PRIMARY KEY CLUSTERED ([Code] ASC)
);

