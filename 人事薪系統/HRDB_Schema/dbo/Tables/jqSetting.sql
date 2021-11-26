CREATE TABLE [dbo].[jqSetting] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [QuerySetting]  NVARCHAR (50)  NOT NULL,
    [QueryName]     NVARCHAR (50)  NOT NULL,
    [SourceType]    NVARCHAR (50)  NOT NULL,
    [ConnectString] NVARCHAR (500) NOT NULL,
    [Memo]          NVARCHAR (500) NOT NULL,
    [CreateMan]     NVARCHAR (50)  NOT NULL,
    [CreateDate]    DATETIME       NOT NULL,
    [Sort]          INT            CONSTRAINT [DF_jqSetting_Sort] DEFAULT ((1)) NOT NULL,
    [PageSize]      INT            CONSTRAINT [DF_jqSetting_PageSize] DEFAULT ((1000)) NOT NULL,
    [CustomerWhere] NVARCHAR (MAX) CONSTRAINT [DF_jqSetting_CustomerWhere] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_jqSetting] PRIMARY KEY CLUSTERED ([ID] ASC)
);

