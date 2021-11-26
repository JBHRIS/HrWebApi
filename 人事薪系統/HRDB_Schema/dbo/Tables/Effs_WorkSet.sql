CREATE TABLE [dbo].[Effs_WorkSet] (
    [autoKey] INT            IDENTITY (1, 1) NOT NULL,
    [yy]      NVARCHAR (10)  NULL,
    [seq]     NVARCHAR (50)  NULL,
    [name]    NVARCHAR (200) NULL,
    [isopen]  BIT            NULL
);

