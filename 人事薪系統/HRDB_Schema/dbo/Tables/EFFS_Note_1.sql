CREATE TABLE [dbo].[EFFS_Note_1] (
    [autoKey]   INT            IDENTITY (1, 1) NOT NULL,
    [year]      NVARCHAR (50)  NULL,
    [seq]       NVARCHAR (50)  NULL,
    [nobr]      NVARCHAR (50)  NULL,
    [cate]      NVARCHAR (50)  NULL,
    [note]      NVARCHAR (MAX) NULL,
    [note_mang] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_EFFS_Note_1] PRIMARY KEY CLUSTERED ([autoKey] ASC)
);

