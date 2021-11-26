CREATE TABLE [dbo].[DOC_ITEM] (
    [AUTO]        INT           IDENTITY (1, 1) NOT NULL,
    [CateGory]    NVARCHAR (50) NOT NULL,
    [CODE]        NVARCHAR (50) NOT NULL,
    [NAME]        NVARCHAR (50) NOT NULL,
    [KEY_DATE]    DATETIME      NOT NULL,
    [KEY_MAN]     NVARCHAR (50) NOT NULL,
    [MEMO]        NVARCHAR (50) NULL,
    [IsNecessary] BIT           NOT NULL,
    [NOTE1]       NVARCHAR (50) NULL,
    [NOTE2]       NVARCHAR (50) NULL,
    [NOTE3]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_DOC_ITEM] PRIMARY KEY CLUSTERED ([AUTO] ASC)
);

