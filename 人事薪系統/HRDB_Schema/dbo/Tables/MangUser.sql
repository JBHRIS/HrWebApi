CREATE TABLE [dbo].[MangUser] (
    [type]     NVARCHAR (50)  NOT NULL,
    [nobr]     NVARCHAR (50)  NOT NULL,
    [name_c]   NVARCHAR (50)  NOT NULL,
    [key_man]  NVARCHAR (50)  NOT NULL,
    [key_date] DATETIME       NOT NULL,
    [Pwd]      NVARCHAR (110) CONSTRAINT [DF_MangUser_Pwd] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_MangUser] PRIMARY KEY CLUSTERED ([nobr] ASC)
);

