CREATE TABLE [dbo].[NotifyParameterDetail] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [NotifyDetailId] INT            NOT NULL,
    [ParameterCode]  NVARCHAR (50)  NOT NULL,
    [ParameterName]  NVARCHAR (50)  NOT NULL,
    [Value]          NVARCHAR (MAX) NOT NULL,
    [DataType]       NVARCHAR (50)  NOT NULL,
    [FieldType]      NVARCHAR (50)  NOT NULL,
    [Source]         NVARCHAR (MAX) NOT NULL,
    [CreateTime]     DATETIME       NOT NULL,
    [CreateMan]      NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_NotifyParameterDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);

