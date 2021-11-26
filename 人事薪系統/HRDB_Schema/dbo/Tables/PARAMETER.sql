CREATE TABLE [dbo].[PARAMETER] (
    [AUTO]           INT           IDENTITY (1, 1) NOT NULL,
    [PARMGROUP_AUTO] INT           NOT NULL,
    [CODE]           NVARCHAR (50) NOT NULL,
    [TYPE]           NVARCHAR (50) NOT NULL,
    [VALUE]          NVARCHAR (50) NOT NULL,
    [KEY_DATE]       DATETIME      NOT NULL,
    [KEY_MAN]        NVARCHAR (50) NOT NULL,
    [NOTE]           NVARCHAR (50) NULL,
    [NOTE1]          NVARCHAR (50) NULL,
    [NOTE2]          NVARCHAR (50) NULL,
    [NOTE3]          NVARCHAR (50) NULL,
    [NOTE4]          NVARCHAR (50) NULL,
    [NOTE5]          NVARCHAR (50) NULL,
    [DISPLAY]        BIT           NOT NULL,
    CONSTRAINT [PK_PARAMETER] PRIMARY KEY CLUSTERED ([AUTO] ASC)
);

