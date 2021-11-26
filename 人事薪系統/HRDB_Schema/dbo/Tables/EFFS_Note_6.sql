CREATE TABLE [dbo].[EFFS_Note_6] (
    [yy]      INT            NULL,
    [seq]     INT            NULL,
    [dept]    NVARCHAR (50)  NULL,
    [num]     DECIMAL (5, 2) NULL,
    [autokey] INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_EFFS_Note_6] PRIMARY KEY CLUSTERED ([autokey] ASC)
);

