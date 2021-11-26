CREATE TABLE [dbo].[HPX_Period_INS_Cost_Code_Sumxx] (
    [YYMM]             NVARCHAR (10)   NOT NULL,
    [INSUR_TYPE]       NVARCHAR (10)   NOT NULL,
    [COMPCODE]         NVARCHAR (20)   NOT NULL,
    [DEPTS]            NVARCHAR (20)   NOT NULL,
    [COMP_AMT]         DECIMAL (16, 2) NOT NULL,
    [Last_Update_Date] DATETIME        DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_HPX_Period_INS_Cost_Code_Sumxx] PRIMARY KEY CLUSTERED ([YYMM] ASC, [INSUR_TYPE] ASC, [COMPCODE] ASC, [DEPTS] ASC)
);

