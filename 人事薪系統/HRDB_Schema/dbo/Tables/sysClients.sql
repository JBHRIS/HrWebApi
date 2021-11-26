CREATE TABLE [dbo].[sysClients] (
    [ClientId]   NVARCHAR (100) NOT NULL,
    [ClientName] NVARCHAR (50)  NOT NULL,
    [DueDate]    DATETIME       NOT NULL,
    [UpdateDate] DATETIME       NOT NULL,
    [Note]       NVARCHAR (200) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([ClientId] ASC)
);

