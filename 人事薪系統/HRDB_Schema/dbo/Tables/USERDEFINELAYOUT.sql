CREATE TABLE [dbo].[USERDEFINELAYOUT] (
    [AK]                INT              IDENTITY (1, 1) NOT NULL,
    [USERDEFINEGROUPID] UNIQUEIDENTIFIER NOT NULL,
    [CONTROLID]         UNIQUEIDENTIFIER NOT NULL,
    [TYPE]              NVARCHAR (50)    NOT NULL,
    [LAYOUTCOLUMN]      INT              NOT NULL,
    [LAYOUTROW]         INT              NOT NULL,
    [COLUMNSPAN]        INT              NOT NULL,
    [ROWSPAN]           INT              NOT NULL,
    [ANCHOR]            NVARCHAR (50)    NULL,
    [DOCK]              NVARCHAR (50)    NULL,
    [TAG]               NVARCHAR (MAX)   NULL,
    [VISIBLE]           BIT              NOT NULL,
    [KEY_MAN]           NVARCHAR (50)    NULL,
    [KEY_DATE]          DATETIME         NULL,
    CONSTRAINT [PK_USERDEFINELAYOUT] PRIMARY KEY CLUSTERED ([AK] ASC)
);

