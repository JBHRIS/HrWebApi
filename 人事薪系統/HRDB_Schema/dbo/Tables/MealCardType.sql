CREATE TABLE [dbo].[MealCardType] (
    [AutoKey]      INT           IDENTITY (1, 1) NOT NULL,
    [NOBR]         NVARCHAR (50) NOT NULL,
    [ADATE]        DATETIME      NOT NULL,
    [BTIME]        NVARCHAR (50) NULL,
    [BTIME_Source] NVARCHAR (50) NOT NULL,
    [MealType]     NVARCHAR (50) NULL,
    [MealGroup]    NVARCHAR (50) NULL,
    [NoTrans]      BIT           NOT NULL,
    [Lost]         BIT           NOT NULL,
    [SeroNo]       NVARCHAR (50) NOT NULL,
    [KEY_MAN]      NVARCHAR (50) NOT NULL,
    [KEY_DATE]     DATETIME      NOT NULL,
    CONSTRAINT [PK_MealCardType] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_NOBR]
    ON [dbo].[MealCardType]([NOBR] ASC);

