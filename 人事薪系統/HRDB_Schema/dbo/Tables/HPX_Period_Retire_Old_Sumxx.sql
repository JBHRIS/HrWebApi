CREATE TABLE [dbo].[HPX_Period_Retire_Old_Sumxx] (
    [Period_Name]      NVARCHAR (10)   NOT NULL,
    [Paycontrol]       NVARCHAR (10)   NOT NULL,
    [Companycode]      NVARCHAR (20)   NOT NULL,
    [Cost_Code]        NVARCHAR (20)   NOT NULL,
    [Amt]              DECIMAL (16, 2) NOT NULL,
    [Last_Update_Date] DATETIME        DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_HPX_Period_Retire_Old_Sum] PRIMARY KEY CLUSTERED ([Period_Name] ASC, [Paycontrol] ASC, [Companycode] ASC, [Cost_Code] ASC)
);

