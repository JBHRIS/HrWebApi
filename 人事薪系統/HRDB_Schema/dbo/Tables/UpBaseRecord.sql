CREATE TABLE [dbo].[UpBaseRecord] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [NOBR]     NVARCHAR (50) NOT NULL,
    [NAME_C]   NVARCHAR (50) NOT NULL,
    [UPDESCR]  TEXT          NOT NULL,
    [KEY_DATE] DATETIME      NOT NULL,
    CONSTRAINT [PK_UpBaseRecord] PRIMARY KEY CLUSTERED ([ID] ASC)
);

