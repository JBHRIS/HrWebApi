CREATE TABLE [dbo].[COMP] (
    [COMP]               NVARCHAR (50)    NOT NULL,
    [COMPNAME]           NVARCHAR (50)    NOT NULL,
    [CHAIRMAN]           NVARCHAR (50)    NOT NULL,
    [COMPID]             NVARCHAR (50)    NOT NULL,
    [TEL]                NVARCHAR (50)    NOT NULL,
    [FAX]                NVARCHAR (50)    NOT NULL,
    [ADDR]               NVARCHAR (120)   NOT NULL,
    [HOUSEID]            NVARCHAR (50)    NOT NULL,
    [KEY_MAN]            NVARCHAR (50)    NOT NULL,
    [KEY_DATE]           DATETIME         NOT NULL,
    [F0103]              NVARCHAR (50)    NOT NULL,
    [F0407]              NVARCHAR (50)    NOT NULL,
    [WORKCD]             NVARCHAR (50)    NOT NULL,
    [TAXID]              NVARCHAR (50)    NOT NULL,
    [ACCOUNT]            NVARCHAR (50)    NOT NULL,
    [ACCR]               NVARCHAR (50)    CONSTRAINT [DF_COMP_ACCR] DEFAULT ('') NOT NULL,
    [DEFA]               BIT              CONSTRAINT [DF_COMP_DEFA] DEFAULT ((0)) NOT NULL,
    [INSCOMP]            NVARCHAR (50)    NOT NULL,
    [COMPENAME]          NVARCHAR (50)    NULL,
    [SORT]               INT              CONSTRAINT [DF_COMP_SORT] DEFAULT ((0)) NOT NULL,
    [MENUGROUPID]        UNIQUEIDENTIFIER NULL,
    [USERDEFINEMASTERID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_COMP] PRIMARY KEY CLUSTERED ([COMP] ASC)
);



