CREATE TABLE [dbo].[sysMoudles] (
    [Code]       NVARCHAR (50)  NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [IsAdmin]    BIT            NOT NULL,
    [KeyMan]     NVARCHAR (50)  NOT NULL,
    [UpdateDate] DATETIME       NOT NULL,
    [Note]       NVARCHAR (200) NULL,
    CONSTRAINT [PK_Moudles] PRIMARY KEY CLUSTERED ([Code] ASC)
);

