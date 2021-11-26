CREATE TABLE [dbo].[USERDEFINEMASTER] (
    [AK]                   INT              IDENTITY (1, 1) NOT NULL,
    [UserDefineMasterID]   UNIQUEIDENTIFIER NOT NULL,
    [UserDefineMasterName] NVARCHAR (50)    NULL,
    [NOTE]                 NVARCHAR (500)   NULL,
    [KEY_MAN]              NVARCHAR (50)    NULL,
    [KEY_DATE]             DATETIME         NULL,
    CONSTRAINT [PK_USERDEFINEMASTER] PRIMARY KEY CLUSTERED ([AK] ASC)
);

