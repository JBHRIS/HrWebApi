CREATE TABLE [dbo].[jqColumn] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [SettingID]   INT            NOT NULL,
    [Sort]        INT            NOT NULL,
    [TableName]   NVARCHAR (50)  NOT NULL,
    [ColumnName]  NVARCHAR (50)  NOT NULL,
    [DisplayName] NVARCHAR (50)  NOT NULL,
    [Display]     BIT            NOT NULL,
    [DataType]    NVARCHAR (50)  NOT NULL,
    [PrimaryKey]  BIT            NOT NULL,
    [Format]      NVARCHAR (50)  NOT NULL,
    [Memo]        NVARCHAR (500) NOT NULL,
    [CreateMan]   NVARCHAR (50)  NOT NULL,
    [CreateDate]  DATETIME       NOT NULL,
    CONSTRAINT [PK_jqColumn] PRIMARY KEY CLUSTERED ([ID] ASC)
);

