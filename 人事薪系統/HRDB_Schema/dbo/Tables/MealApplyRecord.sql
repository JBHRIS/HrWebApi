CREATE TABLE [dbo].[MealApplyRecord] (
    [AutoKey]   INT            IDENTITY (1, 1) NOT NULL,
    [NOBR]      NVARCHAR (50)  NOT NULL,
    [ADATE]     DATETIME       NOT NULL,
    [MealGroup] NVARCHAR (50)  NOT NULL,
    [MealType]  NVARCHAR (50)  NOT NULL,
    [NOTE]      NVARCHAR (500) NULL,
    [SeroNO]    NVARCHAR (50)  NOT NULL,
    [KEY_MAN]   NVARCHAR (50)  NOT NULL,
    [KEY_DATE]  DATETIME       NOT NULL,
    CONSTRAINT [PK_MealApplyRecord] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_NOBR]
    ON [dbo].[MealApplyRecord]([NOBR] ASC);

