CREATE TABLE [dbo].[jqCondition] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [SettingID]   INT            NOT NULL,
    [Sort]        INT            NOT NULL,
    [TableName]   NVARCHAR (50)  NOT NULL,
    [ColumnName]  NVARCHAR (50)  NOT NULL,
    [Comparison]  NVARCHAR (50)  NOT NULL,
    [Value]       NVARCHAR (MAX) NOT NULL,
    [Value1]      NVARCHAR (MAX) NOT NULL,
    [QueryType]   NVARCHAR (50)  NOT NULL,
    [CustomQuery] NVARCHAR (500) NOT NULL,
    [UserID]      NVARCHAR (50)  NOT NULL,
    [Memo]        NVARCHAR (500) NOT NULL,
    [CreateMan]   NVARCHAR (50)  NOT NULL,
    [CreateDate]  DATETIME       NOT NULL,
    CONSTRAINT [PK_jqCondition] PRIMARY KEY CLUSTERED ([ID] ASC)
);

