CREATE TABLE [dbo].[MealCaseSetting] (
    [MealSettingCode] NVARCHAR (50)   NOT NULL,
    [MealGroup]       NVARCHAR (50)   NOT NULL,
    [MealType]        NVARCHAR (50)   NOT NULL,
    [Apply]           BIT             NOT NULL,
    [Attend]          BIT             NOT NULL,
    [OT]              BIT             NOT NULL,
    [Eat]             BIT             NOT NULL,
    [AMT]             DECIMAL (16, 2) NOT NULL,
    [NOTE]            NVARCHAR (500)  NULL,
    [KEY_MAN]         NVARCHAR (50)   NOT NULL,
    [KEY_DATE]        DATETIME        NOT NULL,
    CONSTRAINT [PK_MealCaseSetting] PRIMARY KEY CLUSTERED ([MealSettingCode] ASC)
);

