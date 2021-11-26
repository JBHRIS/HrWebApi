CREATE TABLE [dbo].[EFFS_Note_4] (
    [autoKey] INT            IDENTITY (1, 1) NOT NULL,
    [yy]      NVARCHAR (50)  NULL,
    [seq]     NVARCHAR (50)  NULL,
    [nobr]    NVARCHAR (50)  NULL,
    [adate]   DATETIME       NULL,
    [note1]   NVARCHAR (MAX) NULL,
    [note2]   NVARCHAR (MAX) NULL,
    [num1]    DECIMAL (5, 2) CONSTRAINT [DF_EFFS_Note_4_num1] DEFAULT ((0)) NULL,
    [num2]    DECIMAL (5, 2) CONSTRAINT [DF_EFFS_Note_4_num2] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_EFFS_Note_4] PRIMARY KEY CLUSTERED ([autoKey] ASC)
);

