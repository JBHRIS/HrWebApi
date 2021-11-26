CREATE TABLE [dbo].[EFFS_CATE] (
    [effcateID]   NVARCHAR (4)   NOT NULL,
    [effcateName] NVARCHAR (200) NOT NULL,
    [effcatenote] NTEXT          NULL,
    [TypeID]      NVARCHAR (4)   NULL,
    CONSTRAINT [PK_EFFS_CATE] PRIMARY KEY CLUSTERED ([effcateID] ASC)
);

