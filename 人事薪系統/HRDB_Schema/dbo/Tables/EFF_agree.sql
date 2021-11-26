CREATE TABLE [dbo].[EFF_agree] (
    [yy]         INT            NULL,
    [seq]        INT            NULL,
    [nobr]       NVARCHAR (50)  NULL,
    [agree_date] DATETIME       NULL,
    [agree]      BIT            NULL,
    [agree_note] NVARCHAR (MAX) NULL,
    [key_date]   DATETIME       NULL,
    [key_man]    NVARCHAR (50)  NULL,
    [autoKey]    INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_EFF_agree] PRIMARY KEY CLUSTERED ([autoKey] ASC)
);

