CREATE TABLE [dbo].[sysClientByMoudle] (
    [ClientId]    NVARCHAR (100) NOT NULL,
    [MoudleId]    NVARCHAR (50)  NOT NULL,
    [KeyMan]      NVARCHAR (50)  NOT NULL,
    [UpadateDate] DATETIME       NOT NULL,
    [Note]        NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ClientByMoudle] PRIMARY KEY CLUSTERED ([ClientId] ASC, [MoudleId] ASC)
);

