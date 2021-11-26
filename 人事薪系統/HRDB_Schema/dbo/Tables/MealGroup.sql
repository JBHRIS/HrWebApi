CREATE TABLE [dbo].[MealGroup] (
    [MealGroup_Code] NVARCHAR (50)  NOT NULL,
    [MealGroup_DISP] NVARCHAR (50)  NOT NULL,
    [MealGroup_Name] NVARCHAR (50)  NOT NULL,
    [NOTE]           NVARCHAR (500) NULL,
    [KEY_MAN]        NVARCHAR (50)  NOT NULL,
    [KEY_DATE]       DATETIME       NOT NULL,
    CONSTRAINT [PK_MealGroup] PRIMARY KEY CLUSTERED ([MealGroup_Code] ASC)
);

