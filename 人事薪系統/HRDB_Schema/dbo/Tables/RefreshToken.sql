CREATE TABLE [dbo].[RefreshToken] (
    [RefreshToken] NVARCHAR (100) NOT NULL,
    [Nobr]         NVARCHAR (50)  NULL,
    [DueDate]      DATETIME       NOT NULL,
    [Lock]         INT            NOT NULL,
    [Valid]        NVARCHAR (100) NOT NULL,
    [UpdateTime]   DATETIME       NOT NULL,
    CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED ([RefreshToken] ASC)
);

