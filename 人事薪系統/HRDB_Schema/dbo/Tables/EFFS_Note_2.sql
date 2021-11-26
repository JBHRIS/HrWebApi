CREATE TABLE [dbo].[EFFS_Note_2] (
    [AutoKey]   INT            IDENTITY (1, 1) NOT NULL,
    [year]      NCHAR (10)     NULL,
    [seq]       NCHAR (10)     NULL,
    [nobr]      NCHAR (10)     NULL,
    [chb1]      BIT            NULL,
    [chb2]      BIT            NULL,
    [chb3]      BIT            NULL,
    [chb4]      BIT            NULL,
    [AMT1]      NVARCHAR (50)  NULL,
    [AMT2]      NVARCHAR (50)  NULL,
    [JOBL]      NVARCHAR (50)  NULL,
    [JOBO]      NVARCHAR (50)  NULL,
    [AMT_OTHER] NVARCHAR (50)  NULL,
    [AMT3]      NVARCHAR (50)  NULL,
    [OTHER]     NVARCHAR (50)  NULL,
    [NOTE]      NVARCHAR (MAX) NULL,
    [Key_date]  DATETIME       NULL,
    [Key_Man]   NVARCHAR (50)  NULL,
    CONSTRAINT [PK_EFFS_Note_2] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

