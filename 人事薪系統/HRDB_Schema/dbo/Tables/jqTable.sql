CREATE TABLE [dbo].[jqTable] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [SettingID]   INT            NOT NULL,
    [TableName]   NVARCHAR (50)  NOT NULL,
    [DisplayName] NVARCHAR (50)  NOT NULL,
    [Memo]        NVARCHAR (500) NOT NULL,
    [CreateMan]   NVARCHAR (50)  NOT NULL,
    [CreateDate]  DATETIME       NOT NULL,
    CONSTRAINT [PK_jqTable] PRIMARY KEY CLUSTERED ([ID] ASC)
);

