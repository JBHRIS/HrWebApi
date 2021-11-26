CREATE TABLE [dbo].[jqSqlQueryField] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [SettingID]   INT            NOT NULL,
    [Sort]        INT            NOT NULL,
    [TableName]   NVARCHAR (50)  NOT NULL,
    [ColumnName]  NVARCHAR (50)  NOT NULL,
    [DisplayName] NVARCHAR (50)  NOT NULL,
    [Display]     BIT            NOT NULL,
    [QueryType]   NVARCHAR (50)  NOT NULL,
    [CustomQuery] NVARCHAR (500) NOT NULL,
    [Memo]        NVARCHAR (500) NOT NULL,
    [CreateMan]   NVARCHAR (50)  NOT NULL,
    [CreateDate]  DATETIME       NOT NULL,
    CONSTRAINT [PK_jbSqlQueryField] PRIMARY KEY CLUSTERED ([ID] ASC)
);

