CREATE TABLE [dbo].[FileStructure] (
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
    [OpenNewWin]    BIT            CONSTRAINT [DF_FileStructure_OpenNewWin] DEFAULT ((0)) NOT NULL,
    [NoticeContent] NVARCHAR (MAX) NULL,
    [NoticeTitle]   NVARCHAR (100) NULL,
    [DisplayNotice] BIT            CONSTRAINT [DF_FileStructure_DisplayNotice] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_FileStructure] PRIMARY KEY CLUSTERED ([Code] ASC)
);

