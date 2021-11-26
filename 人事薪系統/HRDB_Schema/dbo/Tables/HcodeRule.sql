CREATE TABLE [dbo].[HcodeRule] (
    [Code]     NVARCHAR (50)   NOT NULL,
    [Interval] NVARCHAR (50)   NOT NULL,
    [Value1]   DECIMAL (16, 2) NOT NULL,
    [Value2]   DECIMAL (16, 2) NOT NULL,
    [Custom]   NVARCHAR (500)  NULL,
    [Note]     NVARCHAR (500)  NULL,
    CONSTRAINT [PK_HcodeRule] PRIMARY KEY CLUSTERED ([Code] ASC)
);

