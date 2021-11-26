CREATE TABLE [dbo].[USERDEFINEGROUP] (
    [AK]                  INT              IDENTITY (1, 1) NOT NULL,
    [USERDEFINEGROUPID]   UNIQUEIDENTIFIER NOT NULL,
    [USERDEFINEGROUPNAME] NVARCHAR (50)    NULL,
    [NOTE]                NVARCHAR (500)   NULL,
    [KEY_MAN]             NVARCHAR (50)    NULL,
    [KEY_DATE]            DATETIME         NULL,
    [COLUMNCNT]           INT              NOT NULL,
    [ROWCNT]              INT              NOT NULL,
    [ITEMSWIDTH]          INT              NOT NULL,
    [ITEMSHEIGHT]         INT              NOT NULL,
    [FormName]            NVARCHAR (50)    NULL,
    [TableLayoutName]     NVARCHAR (50)    NULL,
    [UserDefineMasterID]  UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_USERDEFINEGROUP] PRIMARY KEY CLUSTERED ([AK] ASC)
);

