CREATE TABLE [dbo].[MealDeduction] (
    [AutoKey]   INT             IDENTITY (1, 1) NOT NULL,
    [NOBR]      NVARCHAR (50)   NOT NULL,
    [ADATE]     DATETIME        NOT NULL,
    [YYMM]      NVARCHAR (50)   NULL,
    [MealGroup] NVARCHAR (50)   NOT NULL,
    [MealType]  NVARCHAR (50)   NOT NULL,
    [Apply]     BIT             CONSTRAINT [DF_Table_1_APPLY] DEFAULT ((0)) NOT NULL,
    [Attend]    BIT             CONSTRAINT [DF_Table_1_ATTEND] DEFAULT ((0)) NOT NULL,
    [OT]        BIT             CONSTRAINT [DF_MealDeduction_OT] DEFAULT ((0)) NOT NULL,
    [Eat]       BIT             CONSTRAINT [DF_Table_1_FINISHED] DEFAULT ((0)) NOT NULL,
    [AMT]       DECIMAL (16, 4) CONSTRAINT [DF_MealDeduction_AMT] DEFAULT ((0)) NOT NULL,
    [NOTE]      NVARCHAR (500)  NULL,
    [SERO]      NVARCHAR (50)   NULL,
    [KEY_MAN]   NVARCHAR (50)   NOT NULL,
    [KEY_DATE]  DATETIME        NOT NULL,
    CONSTRAINT [PK_MealDeduction] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

