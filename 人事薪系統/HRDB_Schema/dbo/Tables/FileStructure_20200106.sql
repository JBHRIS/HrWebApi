CREATE TABLE [dbo].[FileStructure_20200106] (
    [Code]          NVARCHAR (200) NOT NULL,
    [sPath]         NVARCHAR (255) NULL,
    [sFileName]     NVARCHAR (255) NULL,
    [sFileTitle]    NVARCHAR (50)  NULL,
    [sDescription]  NVARCHAR (200) NULL,
    [sParentKey]    NVARCHAR (200) NOT NULL,
    [iOrder]        INT            NOT NULL,
    [sKeyMan]       NVARCHAR (50)  NULL,
    [dKeyDate]      DATETIME       NULL,
    [sIconPath]     NVARCHAR (255) NULL,
    [sIconName]     NVARCHAR (255) NULL,
    [OpenNewWin]    BIT            NOT NULL,
    [NoticeContent] NVARCHAR (MAX) NULL,
    [NoticeTitle]   NVARCHAR (100) NULL,
    [DisplayNotice] BIT            NOT NULL
);

