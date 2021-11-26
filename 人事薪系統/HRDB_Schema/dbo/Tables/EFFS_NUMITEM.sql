CREATE TABLE [dbo].[EFFS_NUMITEM] (
    [autoKey] INT            NOT NULL,
    [numID]   NVARCHAR (4)   NOT NULL,
    [numName] NVARCHAR (10)  NOT NULL,
    [minNum]  DECIMAL (6, 2) NOT NULL,
    [maxNum]  DECIMAL (6, 2) NOT NULL,
    [minRate] DECIMAL (6, 2) NULL,
    [maxRate] DECIMAL (6, 2) NULL
);

