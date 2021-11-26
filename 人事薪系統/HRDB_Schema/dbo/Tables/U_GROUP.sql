CREATE TABLE [dbo].[U_GROUP] (
    [GROUP_ID]   NVARCHAR (50) NOT NULL,
    [GROUP_NAME] NVARCHAR (50) NULL,
    [PROG]       NVARCHAR (50) NOT NULL,
    [ADD_]       BIT           NULL,
    [EDIT]       BIT           NULL,
    [DELE]       BIT           NULL,
    [PRINT_]     BIT           NULL,
    [SYSTEM]     NVARCHAR (50) NULL,
    [KEY_MAN]    NVARCHAR (50) NULL,
    [KEY_DATE]   DATETIME      NULL,
    CONSTRAINT [PK_U_GROUP] PRIMARY KEY CLUSTERED ([GROUP_ID] ASC, [PROG] ASC)
);

